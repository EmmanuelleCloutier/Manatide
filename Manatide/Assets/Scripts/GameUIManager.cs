using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

	[Header("Overlays")]
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


	[Header("UI")]
	public TextMeshProUGUI coinsText;
	public TextMeshProUGUI foodText;
	public TextMeshProUGUI BiomeText;
	public Button btnInfo; 
	public Button btnBiome;
	public Button btnShop;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        
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

	public void Normal()
	{
		HideMainUI();
		BiomeText.gameObject.SetActive(true);
		coinsText.gameObject.SetActive(true);
		foodText.gameObject.SetActive(true);
		btnInfo.gameObject.SetActive(true);
		btnBiome.gameObject.SetActive(true);
		btnShop.gameObject.SetActive(true);
	}

 
	public void HideEverything()
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

		coinsText.gameObject.SetActive(false);
		foodText.gameObject.SetActive(false);
		BiomeText.gameObject.SetActive(false);
		btnInfo.gameObject.SetActive(false);
		btnBiome.gameObject.SetActive(false);
		btnShop.gameObject.SetActive(false);
	}



    public void MuteAudio()
    {
        AudioListener.volume = (AudioListener.volume == 0f) ? 1f : 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
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

	public void ReturnToShop()
	{
		HideMainUI();
		overlayShop.SetActive(true);
	}

	public void ShowOverlayManateeUI()
	{ 
		HideEverything();
		manateeUI.SetActive(true);
	}
}
