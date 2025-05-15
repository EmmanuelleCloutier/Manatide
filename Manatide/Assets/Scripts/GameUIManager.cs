using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

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
    public GameObject overlayShopBiome;
    public GameObject overlayShopFood;
	public GameObject overlayShopManatee;
	public GameObject overlayShopCreature;
	public GameObject overlayShopDecoration;

    public GameObject manateeInfoParent; // conteneur qui contient tous les enfants manatee
    public GameObject manateeInfoPrefab; // prefab avec image, nom, lvl

    public Button btnKelp;
    public Button btnEpave;

    private int coins = 100;
    private int food = 0;
    private int foodBought = 0;

    private bool kelpBought = false;
    private bool epaveBought = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        UpdateUI();
        RefreshBiomeButtons();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coins;
        foodText.text = "Food: " + food;
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

    public void ToggleOverlay(GameObject overlay)
    {
        overlay.SetActive(!overlay.activeSelf);
    }

    public void OpenShop() => ToggleOverlay(overlayShop);
    public void OpenBiomes() => ToggleOverlay(overlayBiomes);
    public void OpenShopBiome() => ToggleOverlay(overlayShopBiome);
    public void OpenShopFood() => ToggleOverlay(overlayShopFood);
    public void OpenManateeInfo() => ToggleOverlay(overlayManateeInfo);

    public void HideMainUI()
    {
        overlayShop.SetActive(false);
        overlayBiomes.SetActive(false);
        overlayManateeInfo.SetActive(false);
  		overlayShopManatee.SetActive(false);
  		overlayShopCreature.SetActive(false);
    	overlayShopDecoration.SetActive(false);
        overlayShopBiome.SetActive(false);
        overlayShopFood.SetActive(false);
        manateeUI.SetActive(false);
    }

    public void MuteAudio()
    {
        AudioListener.volume = (AudioListener.volume == 0f) ? 1f : 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Achat de manatee
    public void BuyManatee(GameObject prefab, int cost, string name)
    {
        if (coins < cost) return;

        coins -= cost;
        UpdateUI();

        // Ajouter au UI info
        GameObject newInfo = Instantiate(manateeInfoPrefab, manateeInfoParent.transform);
        newInfo.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
        newInfo.transform.Find("LvlText").GetComponent<TextMeshProUGUI>().text = "LVL 0";
        // (si tu veux mettre une sprite)
        // newInfo.transform.Find("ImageSprite").GetComponent<Image>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
    }

    // Achat de nourriture (3 max)
    public void BuyFood()
    {
        if (foodBought >= 3) return;

        int price = 50 * (foodBought + 1);
        if (coins < price) return;

        coins -= price;
        foodBought++;
        food++;
        UpdateUI();

        // TODO: mettre à jour l'affichage du prix et "sold" dans l'UI
        if (foodBought == 3)
        {
            Debug.Log("Food max acheté (3/3)");
            // désactiver le bouton ou afficher "Sold"
        }
    }

    // Achat de biome
    public void BuyBiome(string biome)
    {
        if (biome == "kelp" && !kelpBought && coins >= 500)
        {
            coins -= 500;
            kelpBought = true;
        }
        else if (biome == "epave" && !epaveBought && coins >= 1000)
        {
            coins -= 1000;
            epaveBought = true;
        }

        UpdateUI();
        RefreshBiomeButtons();
    }

    void RefreshBiomeButtons()
    {
        btnKelp.interactable = kelpBought;
        btnEpave.interactable = epaveBought;
    }

	public void ShowOverlayShopManatee()
	{
		HideMainUI();
		overlayShopManatee.SetActive(true);
	}

	public void ShowOverlayShopCreature()
	{
   	 	HideMainUI();
   	 	overlayShopCreature.SetActive(true);
	}

	public void ShowOverlayShopDecoration()
	{
    HideMainUI();
    overlayShopDecoration.SetActive(true);
	}

	public void ShowOverlayShopBiome()
	{
    	HideMainUI();
    	overlayShopBiome.SetActive(true);
	}

	public void ShowOverlayShopFood()
	{	
    	HideMainUI();
    	overlayShopFood.SetActive(true);
	}

}
