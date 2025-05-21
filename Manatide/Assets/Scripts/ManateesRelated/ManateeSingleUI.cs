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
    public TextMeshProUGUI feedButtonText;

    [Header("Ressources")]
    public PlayerState playerState;

    private ItemManatee currentManatee;
    private const int MaxLevel = 10;
    private const int FeedCost = 150;

    void Awake()
    {
        Instance = this;
    }

    public void Display(ItemManatee manatee, Sprite sprite)
    {
        currentManatee = manatee;
        nameText.text = manatee.itemName;

        UpdateLevelUI();

        if (sprite != null)
            spriteImage.sprite = sprite;

        gameObject.SetActive(true);
    }

    public void OnFeedButtonClicked()
    {
        if (currentManatee == null) return;

        // Vérifie niveau max
        if (currentManatee.lvl >= MaxLevel) return;

        // Vérifie si on a assez de nourriture
        if (playerState.food < FeedCost) return;

        // Dépense et augmente le niveau
        playerState.food -= FeedCost;
        currentManatee.lvl += 1;

        UpdateLevelUI();
    }

    private void UpdateLevelUI()
    {
        levelText.text = currentManatee.lvl.ToString();

        if (currentManatee.lvl >= MaxLevel)
        {
            feedButtonText.text = "MAX";
            feedButton.interactable = false;
        }
        else if (playerState.food < FeedCost)
        {
            feedButtonText.text = "150";
            feedButton.interactable = false;
        }
        else
        {
            feedButtonText.text = "150";
            feedButton.interactable = true;
        }
    }

    void OnEnable()
    {
        playerState.OnFoodChanged += UpdateLevelUI;
    }

    void OnDisable()
    {
        playerState.OnFoodChanged -= UpdateLevelUI;
    }
}
