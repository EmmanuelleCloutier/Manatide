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

    [Header("Sprites selon le type")]
    public List<ManateeTypeSpritePair> spriteByTypeList;

    private Dictionary<ManateeType, Sprite> spriteByType;

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
            // Vérifie qu'il est dans le biome courant
            if ((int)manatee.biome != playerState.lvl)
                continue;

            GameObject card = Instantiate(manateeCardPrefab, contentParent);

            // Assignation des éléments visuels
            card.transform.Find("NameText").GetComponent<TMP_Text>().text = manatee.itemName;
            card.transform.Find("LvlText").GetComponent<TMP_Text>().text = "Lvl " + manatee.lvl;

            if (spriteByType.TryGetValue(manatee.type, out Sprite sprite))
            {
                card.transform.Find("ManateeSprite").GetComponent<Image>().sprite = sprite;
            }
        }
    }
}