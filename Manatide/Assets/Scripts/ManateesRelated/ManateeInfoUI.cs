
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ManateeTypeSpritePair
{
    public ManateeType type;
    public Sprite sprite;
}

public class ManateeInfoUI : MonoBehaviour
{
    [Header("Références")]
    public GameObject manateeCardPrefab; // Ton prefab UI
    public Transform contentParent; // Le Content du Scroll View
    public ManateeManager manateeManager; // Ton ManateeManager
    public PlayerState playerState; // Pour le biome actuel

    [Header("Sprites selon le type pour manateemanager")]
    public List<ManateeTypeSpritePair> spriteByTypeList;
    private Dictionary<ManateeType, Sprite> spriteByType;

    [Header("Sprites")]
    public Sprite Type1;
    public Sprite Type2;
    public Sprite Type3;
    public Sprite Type12;
    public Sprite Type13;
    public Sprite Type23;
    public Sprite Type123;

    private GameObject currentManateeInfo;

    [Header("Manatee Detail UI")]
    public GameObject overlayManateeUI;

    void Awake()
    {
        spriteByType = new Dictionary<ManateeType, Sprite>();

        foreach (var pair in spriteByTypeList)
        {
            spriteByType[pair.type] = pair.sprite;
        }
    }

    void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var manatee in manateeManager.ownedManatees)
        {
            if ((int)manatee.biome != playerState.lvl)
                continue;

            GameObject card = Instantiate(manateeCardPrefab, contentParent);

            ManateeCardUI cardUI = card.GetComponent<ManateeCardUI>();

            cardUI.nameText.text = manatee.itemName;
            cardUI.lvlText.text = manatee.lvl.ToString();

            // NEW - Ajouter le clic sur la carte
            Button cardButton = card.GetComponent<Button>();

            if (cardButton == null)
                cardButton = card.GetComponentInChildren<Button>();

            if (cardButton != null)
            {
                ItemManatee selectedManatee = manatee;

                cardButton.onClick.AddListener(() =>
                {
                    OpenManateeInfo(selectedManatee);
                });
            }

            switch (manatee.type)
            {
                case ManateeType.Type1:
                    cardUI.manateeSprite.sprite = Type1;
                    break;

                case ManateeType.Type2:
                    cardUI.manateeSprite.sprite = Type2;
                    break;

                case ManateeType.Type3:
                    cardUI.manateeSprite.sprite = Type3;
                    break;

                case ManateeType.Type12:
                    cardUI.manateeSprite.sprite = Type12;
                    break;

                case ManateeType.Type13:
                    cardUI.manateeSprite.sprite = Type13;
                    break;

                case ManateeType.Type23:
                    cardUI.manateeSprite.sprite = Type23;
                    break;

                case ManateeType.Type123:
                    cardUI.manateeSprite.sprite = Type123;
                    break;

                default:
                    // Optionnel : sprite par défaut ou vide
                    cardUI.manateeSprite.sprite = null;
                    break;
            }
        }
    }

    // NEW - Open selected Manatee information
    public void OpenManateeInfo(ItemManatee manatee)
    {
        if (manatee == null)
            return;

        // Get the sprite corresponding to the Manatee type
        Sprite selectedSprite = null;

        switch (manatee.type)
        {
            case ManateeType.Type1:
                selectedSprite = Type1;
                break;

            case ManateeType.Type2:
                selectedSprite = Type2;
                break;

            case ManateeType.Type3:
                selectedSprite = Type3;
                break;

            case ManateeType.Type12:
                selectedSprite = Type12;
                break;

            case ManateeType.Type13:
                selectedSprite = Type13;
                break;

            case ManateeType.Type23:
                selectedSprite = Type23;
                break;

            case ManateeType.Type123:
                selectedSprite = Type123;
                break;
        }

        // Open the existing Manatee UI
        GameUIManager.Instance.ShowOverlayManateeUI();

        // Display the selected Manatee information
        ManateeSingleUI.Instance.Display(manatee, selectedSprite);

        Debug.Log("Selected Manatee: " + manatee.itemName);
    }
}
