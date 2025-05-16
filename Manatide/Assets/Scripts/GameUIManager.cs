using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;


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

}
