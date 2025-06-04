using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BreedingUIManager : MonoBehaviour
{
	[Header("UI")]
    public GameObject breedingCardPrefab;
    public Transform leftParent;
    public Transform rightParent;
    public Button breedButton;
	public TMP_Text breedingResultText;

	[Header("SpawnManatee")]
	public NameGenerator nameGenerator;
    public ManateeManager manateeManager;
    public ManateeInfoUI manateeInfoUI;
	public Transform spawnPoint;

	[Header("PrefabTypeManatee")]
	public GameObject prefabManateeType12;
	public GameObject prefabManateeType13;
	public GameObject prefabManateeType23;
	public GameObject prefabManateeType123;
	public PlayerState playerState;

    private ItemManatee selectedLeft;
    private ItemManatee selectedRight;
    private List<ManateeBreedingCard> leftCards = new();
    private List<ManateeBreedingCard> rightCards = new();

    void OnEnable()
    {
        RefreshBreedingUI();
    }

   void RefreshBreedingUI()
{
    ClearCards();

    // On récupère le biome actuel du joueur
    Biome currentBiome = (Biome)playerState.lvl;

    foreach (var manatee in manateeManager.ownedManatees)
    {
        // On garde uniquement les manatees du biome actif ET niveau 5+
        if (manatee.lvl >= 5 && manatee.biome == currentBiome)
        {
            Sprite sprite = manateeManager.GetSpriteForType(manatee.type);

            var leftCard = Instantiate(breedingCardPrefab, leftParent).GetComponent<ManateeBreedingCard>();
            leftCard.Setup(manatee, sprite, OnLeftManateeSelected);
            leftCards.Add(leftCard);

            var rightCard = Instantiate(breedingCardPrefab, rightParent).GetComponent<ManateeBreedingCard>();
            rightCard.Setup(manatee, sprite, OnRightManateeSelected);
            rightCards.Add(rightCard);
        }
    }

    UpdateBreedButton();
}

    void ClearCards()
    {
        foreach (Transform child in leftParent) Destroy(child.gameObject);
        foreach (Transform child in rightParent) Destroy(child.gameObject);
        leftCards.Clear();
        rightCards.Clear();
        selectedLeft = null;
        selectedRight = null;
    }

    void OnLeftManateeSelected(ItemManatee manatee)
    {
        selectedLeft = manatee;
        UpdateRightColumnInteractability();
        UpdateBreedButton();
    }

    void OnRightManateeSelected(ItemManatee manatee)
    {
        selectedRight = manatee;
		UpdateLeftColumnInteractability();
        UpdateBreedButton();
    }

    void UpdateRightColumnInteractability()
    {
        foreach (var card in rightCards)
        {
            bool isSame = selectedLeft != null && card.GetManateeData() == selectedLeft;
            card.SetInteractable(!isSame);
        }
    }

	void UpdateLeftColumnInteractability()
    {
        foreach (var card in leftCards)
        {
            bool isSame = selectedRight != null && card.GetManateeData() == selectedRight;
            card.SetInteractable(!isSame);
        }
    }

    void UpdateBreedButton()
    {
        breedButton.interactable = selectedLeft != null && selectedRight != null;
    }
    private IEnumerator DelayedBreedingUIRefresh()
    {
        yield return null; // attendre une frame (évite les race conditions)

        if (manateeInfoUI != null)
        {
            manateeInfoUI.RefreshUI(); // évite les crashs liés à une liste pas encore prête
        }

        RefreshBreedingUI(); // met à jour la liste de breeding
    }

public void OnBreedButtonClicked()
{
    if (manateeManager.playerState.coins < 250)
    {
        breedingResultText.text = "Pas assez d'argent ! (250$ requis)";
        return;
    }
    manateeManager.playerState.SpendCoins(250);

    int chance = CalculateBreedingChance(selectedLeft.type, selectedRight.type);
    bool success = Random.Range(0f, 1f) <= (chance / 100f);

    if (success)
    {
        var newType = GetNewManateeType(selectedLeft.type, selectedRight.type);
        string generatedName = nameGenerator.GenerateName();
        ItemManatee newManatee = new ItemManatee
        {
            itemName = generatedName,
            lvl = 1,
            type = newType,
            biome = (Biome)manateeManager.playerState.lvl
        };
        
        manateeManager.AddManatee(newManatee);
        GameObject prefabToSpawn = null;

        switch ((int)newType)
        {
            case 12:
                prefabToSpawn = prefabManateeType12;
                break;
            case 13:
                prefabToSpawn = prefabManateeType13;
                break;
            case 23:
                prefabToSpawn = prefabManateeType23;
                break;
            case 123:
                prefabToSpawn = prefabManateeType123;
                break;
            default:
                Debug.LogWarning("Type de manatee inconnu : " + newType);
                break;
        }

        if (prefabToSpawn != null)
        {
            GameObject instance = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
            manateeManager.spawnedManatees.Add(instance);

            AIManatee ai = instance.GetComponent<AIManatee>();
            if (ai != null)
            {
                ai.data = newManatee;
                ai.sprite = manateeManager.GetSpriteForType(newManatee.type);
            }
        }

        StartCoroutine(DelayedBreedingUIRefresh());

        breedingResultText.text = "Success !";
    }
    else
    {
        breedingResultText.text = "Fail Try again !";
    }

    RefreshBreedingUI();
}


    int CalculateBreedingChance(ManateeType left, ManateeType right)
    {
        bool isLeftMixed = ((int)left).ToString().Length > 1;
        bool isRightMixed = ((int)right).ToString().Length > 1;

        return (isLeftMixed || isRightMixed) ? 25 : 50;
    }

    ManateeType GetNewManateeType(ManateeType left, ManateeType right)
    {
        string combined = ((int)left).ToString() + ((int)right).ToString();
        var uniqueDigits = new HashSet<char>(combined);
        var sorted = new List<char>(uniqueDigits);
        sorted.Sort();
        string resultStr = new string(sorted.ToArray());
        int resultInt = int.Parse(resultStr);

        return (ManateeType)resultInt;
    }
}
