using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class ManateeBreedingCard : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Image manateeImage;
	public TMP_Text TypeText;
    private ItemManatee manateeData;
    public Button selectButton;

	public static string GetTypeName(ManateeType type)
	{
    	switch (type)
    	{
        	case ManateeType.Type1: return "Type 1";
        	case ManateeType.Type2: return "Type 2";
        	case ManateeType.Type3: return "Type 3";
        	case ManateeType.Type12: return "Type 12";
        	case ManateeType.Type13: return "Type 13";
        	case ManateeType.Type23: return "Type 23";
        	case ManateeType.Type123: return "Type 123";
        	default: return "Inconnu";
    	}
	}
    public void Setup(ItemManatee data, Sprite sprite, System.Action<ItemManatee> onClickCallback)
    {
        manateeData = data;
        nameText.text = data.itemName;
        levelText.text = data.lvl.ToString();
        manateeImage.sprite = sprite;
		TypeText.text = GetTypeName(data.type); 

        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => onClickCallback?.Invoke(manateeData));
    }

    public ItemManatee GetManateeData()
    {
        return manateeData;
    }

    public void SetInteractable(bool value)
    {
        selectButton.interactable = value;
    }
}