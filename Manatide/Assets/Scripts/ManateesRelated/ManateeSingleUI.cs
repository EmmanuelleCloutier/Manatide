using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManateeSingleUI : MonoBehaviour
{
    public static ManateeSingleUI Instance;

    [Header("UI Références")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Image spriteImage;
    public Button feedButton;

    private ItemManatee currentManatee;

    void Awake()
    {
        Instance = this;
    }

    public void Display(ItemManatee manatee, Sprite sprite)
    {
        currentManatee = manatee;
        nameText.text = manatee.itemName;
        levelText.text = "Lvl " + manatee.lvl;
        if (sprite != null)
            spriteImage.sprite = sprite;

        gameObject.SetActive(true);
    }

    public void OnFeedButtonClicked()
    {
        if (currentManatee != null)
        {
            currentManatee.lvl += 1;
            levelText.text = "Lvl " + currentManatee.lvl;
        }
    }
}
