using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BreedingUIManager : MonoBehaviour
{
    public GameObject breedingCardPrefab;
    public Transform leftParent;
    public Transform rightParent;
    public Button breedButton;
	public TMP_Text breedingResultText;

    public ManateeManager manateeManager;
    public ManateeInfoUI manateeInfoUI;

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

        foreach (var manatee in manateeManager.ownedManatees)
        {
            if (manatee.lvl >= 5)
            {
                Sprite sprite = manateeManager.GetSpriteForType(manatee.type);

                // LEFT
                var leftCard = Instantiate(breedingCardPrefab, leftParent).GetComponent<ManateeBreedingCard>();
                leftCard.Setup(manatee, sprite, OnLeftManateeSelected);
                leftCards.Add(leftCard);

                // RIGHT
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

    void UpdateBreedButton()
    {
        breedButton.interactable = selectedLeft != null && selectedRight != null;
    }

    public void OnBreedButtonClicked()
    {
        int chance = CalculateBreedingChance(selectedLeft.type, selectedRight.type);
        bool success = Random.Range(0f, 1f) <= (chance / 100f);

        if (success)
		{
    		var newType = GetNewManateeType(selectedLeft.type, selectedRight.type);
    		ItemManatee newManatee = new ItemManatee
    	{
        	itemName = "New Baby",
        	lvl = 1,
        	type = newType,
        	biome = (Biome)manateeManager.playerState.lvl
    	};

    	manateeManager.AddManatee(newManatee);
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
        // Combine les chiffres et trie-les pour éviter des doublons incohérents
        string combined = ((int)left).ToString() + ((int)right).ToString();
        var uniqueDigits = new HashSet<char>(combined);
        var sorted = new List<char>(uniqueDigits);
        sorted.Sort();
        string resultStr = new string(sorted.ToArray());
        int resultInt = int.Parse(resultStr);

        return (ManateeType)resultInt;
    }
}
