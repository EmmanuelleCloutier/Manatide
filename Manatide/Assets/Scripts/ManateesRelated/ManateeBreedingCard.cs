using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class ManateeBreedingCard : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Image manateeImage;
    private ItemManatee manateeData;

    public Button selectButton;

    public void Setup(ItemManatee data, Sprite sprite, System.Action<ItemManatee> onClickCallback)
    {
        manateeData = data;
        nameText.text = data.itemName;
        levelText.text = data.lvl.ToString();
        manateeImage.sprite = sprite;

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