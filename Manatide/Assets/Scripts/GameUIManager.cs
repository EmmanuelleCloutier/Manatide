using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI foodText;

    public GameObject overlayShop;
    public GameObject overlayBiomes;
    public GameObject overlayManateeInfo;
    public GameObject overlayBreeding;
    public GameObject manateeUI;
    
    
    private int coins = 100;
    private int food = 20;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public void AddFood(int amount)
    {
        food += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coins;
        foodText.text = "Food: " + food;
    }

    public void ToggleOverlay(GameObject overlay)
    {
        overlay.SetActive(!overlay.activeSelf);
    }

    public void HideMainUI()
    {
        overlayShop.SetActive(false);
        overlayBiomes.SetActive(false);
        overlayManateeInfo.SetActive(false);
    }

    public void ShowManateeUI(GameObject ui)
    {
        HideMainUI();
        manateeUI.SetActive(true);
    }

    public void MuteAudio()
    {
        AudioListener.volume = (AudioListener.volume == 0f) ? 1f : 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
