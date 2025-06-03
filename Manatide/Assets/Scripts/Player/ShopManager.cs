using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;


public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
	public PlayerState playerState;
	NameGenerator nameGenerator;


	[Header("Ressources")]
	public TextMeshProUGUI coinsText;
	public TextMeshProUGUI foodText;
	public Transform spawnPoint;
	public TextMeshProUGUI BiomeText;
	public ManateeManager manateeManager;


  	[Header("Biomes")]
    public Button btnKelpShop;
    public int PriceBKelp;
    public TextMeshProUGUI KelpText;
	public Button btnKelpBiome;
    public Button btnEpave;
    public int PriceBEpave;
    public TextMeshProUGUI EpaveText;
	public Button btnEpaveBiome;
   
    
    [Header("Manatees")]
    public Button btnManatee1;
    public int PriceM1;
    public GameObject prefabManateeType1;
    public Button btnManatee2;
    public int PriceM2;
    public GameObject prefabManateeType2;
    public Button btnManatee3;
    public int PriceM3;   
    public GameObject prefabManateeType3;
    
  	[Header("Food")]
    public Button btFood;
	public TextMeshProUGUI FoodText;
	public TextMeshProUGUI PriceText;
	public TextMeshProUGUI LimitText;
    public int PriceFood;
	public int MaxLimit; 
	public int NbPressed;

	public Button btnPack1;
	public int PricePack1;
	public int FoodPack1;

	public Button btnPack2;
	public int PricePack2;
	public int FoodPack2;

	public Button btnPack3;
	public int PricePack3;
	public int FoodPack3;

	public Button btnPack4;
	public int PricePack4;
	public int FoodPack4;

	[Header("Algues")]
	public GameObject algue1;
	public GameObject algue2;
	public GameObject algue3;



	void Start()
	{
		LoadGame();
  		playerState.OnCoinsChanged += UpdateCoinsUI;
    	playerState.OnFoodChanged += UpdateFoodUI;
		//Ressources
  		UpdateCoinsUI();
		UpdateBiomeUI();
		UpdateFoodUI();
	

		//Manatees
		nameGenerator = Object.FindFirstObjectByType<NameGenerator>();

		//Biomes
		VerifBiome();
	}
	
//Saving or resetting the game
	public void SaveGame()
	{
		manateeManager.SaveManatees();
		SaveSystem.Save(playerState, NbPressed);
		Debug.Log("Jeu sauvegardé !");
	}

	public void LoadGame()
	{
		SaveData data = SaveSystem.Load();
		if (data != null)
		{
			playerState.coins = data.coins;
			playerState.food = data.food;
			playerState.lvl = data.lvl;
			playerState.BiomeKelp = data.biomeKelp;
			playerState.BiomeEpave = data.biomeEpave;
			NbPressed = data.nbPressed;

			// Rafraîchir les UI et l'état visuel
			UpdateCoinsUI();
			UpdateFoodUI();
			UpdateBiomeUI();
			VerifBiome();
			UpdateFoodAlgueUI();

			UpdatePlantesVisibility();

			Debug.Log("Jeu chargé !");
		}
	}
	
	public void ResetGame()
	{
		// Reset player state (coins, food, lvl, etc.)
		playerState.ResetPlayerState();

		// Supprimer tous les manatees
		manateeManager.DeleteAllManatees();

		// Remettre à jour UI
		manateeManager.manateeInfoUI.RefreshUI();
		UpdateCoinsUI();
		UpdateFoodUI();
		UpdateBiomeUI();
		VerifBiome();
    
		UpdatePlantesVisibility();

		// Réinitialiser le compteur
		NbPressed = 0;
		UpdateFoodAlgueUI();

		// Supprimer sauvegarde complète
		PlayerPrefs.DeleteKey("SavedManatees");
		PlayerPrefs.DeleteKey("playerSave");
		PlayerPrefs.Save();

		// remettre les ressources de base
		playerState.AddCoins(15000);
		playerState.AddFood(15000);

		// Sauvegarder immédiatement pour recréer les fichiers
		SaveGame();
		
		manateeManager.LoadManatees();
	}


	
	public void OnNewGameButtonPressed()
	{
		ResetGame();

		// Si tu sauvegardes la progression dans un fichier ou PlayerPrefs, n'oublie pas de supprimer la sauvegarde
		PlayerPrefs.DeleteKey("playerSave");
	}



//Update les informations ---------------------------------------------------
	 public void UpdateBiomeUI()
    {
        string biome = GetBiomeName(playerState.lvl);
        BiomeText.text = biome;
    }

    string GetBiomeName(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return "Crystalline Lagoon";
            case 2:
				return "Kelp Forest";
            case 3:
                return "Sunken Shipwreck";
            default:
                return "Pas suppose";
        }
    }
		

	public void UpdateCoinsUI()
	{
    	coinsText.text = playerState.coins.ToString() + " coins";
	}

	public void UpdateFoodUI()
	{
		foodText.text = playerState.food.ToString() + " food";
	}

//Biome -----------------------------------

	public void VerifBiome()
	{
		//biome kelp
		if (!playerState.BiomeKelp)
		{	
			 btnKelpBiome.gameObject.SetActive(false);
		}
		else {
			KelpText.text = "Sold";
            btnKelpBiome.gameObject.SetActive(true);
		}

		//biome epave
		if (!playerState.BiomeKelp)
		{	
			 btnEpaveBiome.gameObject.SetActive(false);
		}
		else {
			EpaveText.text = "Sold";
            btnEpaveBiome.gameObject.SetActive(true);
		}

		//food 
		UpdateFoodUI();
	}

    public void BuyBiomeKelp()
    {
        if (!playerState.BiomeKelp)
        {
            if (playerState.coins >= PriceBKelp)
            {
                playerState.coins -= PriceBKelp;
                playerState.BiomeKelp = true;
				
                KelpText.text = "Sold";
				UpdateCoinsUI();
                btnKelpBiome.gameObject.SetActive(true);

            }
        }
        else
        {
            KelpText.text = "Sold";
            btnKelpBiome.gameObject.SetActive(true);
        }
    }

    public void BuyBiomeEpave()
    {
        if (!playerState.BiomeEpave)
        {
            if (playerState.coins >= PriceBEpave)
            {
                playerState.coins -= PriceBEpave;
                playerState.BiomeEpave = true;
				
                EpaveText.text = "Sold";
				UpdateCoinsUI();
                btnEpaveBiome.gameObject.SetActive(true);
            }
        }
        else
        {
            EpaveText.text = "Sold";
			UpdateCoinsUI();
            btnEpaveBiome.gameObject.SetActive(true);
        }
    }

//Manatee ----------------------------------------------------------------
private IEnumerator DelayedRefreshUI()
{
    yield return null; // attendre une frame pour laisser Unity finir d'instancier et de mettre à jour

    if (manateeManager != null && manateeManager.manateeInfoUI != null)
    {
        manateeManager.manateeInfoUI.RefreshUI();
    }
    else
    {
        Debug.LogWarning("manateeManager ou manateeInfoUI est null.");
    }
}

public void BuyManateeType1()
{
    if (playerState.coins >= PriceM1)
    {
       
        string generatedName = nameGenerator.GenerateName();
        ItemManatee newManatee = new ItemManatee
        {
            itemName = generatedName,
            lvl = 1,
            type = ManateeType.Type1,
            biome = (Biome)playerState.lvl

        };

     
        GameObject instance = Instantiate(prefabManateeType1, spawnPoint.position, Quaternion.identity);

     
        manateeManager.AddManatee(newManatee);
        manateeManager.spawnedManatees.Add(instance);

        AIManatee ai = instance.GetComponent<AIManatee>();
        if (ai != null)
        {
            ai.data = newManatee;
            ai.sprite = manateeManager.GetSpriteForType(newManatee.type);
        }

        StartCoroutine(DelayedRefreshUI());
        UpdateCoinsUI();

        playerState.coins -= PriceM1;
    }
}


public void BuyManateeType2()
{
    if (playerState.coins >= PriceM2)
    {
        string generatedName = nameGenerator.GenerateName();
        ItemManatee newManatee = new ItemManatee
        {
            itemName = generatedName,
            lvl = 1,
            type = ManateeType.Type2,
            biome = (Biome)playerState.lvl

        };

        GameObject instance = Instantiate(prefabManateeType2, spawnPoint.position, Quaternion.identity);

        manateeManager.AddManatee(newManatee);
        manateeManager.spawnedManatees.Add(instance);

        AIManatee ai = instance.GetComponent<AIManatee>();
        if (ai != null)
        {
            ai.data = newManatee;
            ai.sprite = manateeManager.GetSpriteForType(newManatee.type);
        }

       StartCoroutine(DelayedRefreshUI());
        UpdateCoinsUI();

        playerState.coins -= PriceM2;
    }
}


public void BuyManateeType3()
{
    if (playerState.coins >= PriceM3)
    {
        string generatedName = nameGenerator.GenerateName();
        ItemManatee newManatee = new ItemManatee
        {
            itemName = generatedName,
            lvl = 1,
            type = ManateeType.Type3,
            biome = (Biome)playerState.lvl

        };

        GameObject instance = Instantiate(prefabManateeType3, spawnPoint.position, Quaternion.identity);

        manateeManager.AddManatee(newManatee);
        manateeManager.spawnedManatees.Add(instance);

        AIManatee ai = instance.GetComponent<AIManatee>();
        if (ai != null)
        {
            ai.data = newManatee;
            ai.sprite = manateeManager.GetSpriteForType(newManatee.type);
        }

       StartCoroutine(DelayedRefreshUI());
        UpdateCoinsUI();

        playerState.coins -= PriceM3;
    }
}


//Food------------------------------------------------------

	public void UpdateFoodAlgueUI()
	{
		LimitText.text = NbPressed + "/3";
	}

  public void UpdatePlantesVisibility()
{
	NbPressed = 0;
	algue1.SetActive(false);
	algue2.SetActive(false);
	algue3.SetActive(false);

	switch (playerState.lvl)
	{
		case 1:
			if (playerState.PlanteL1) { algue1.SetActive(true); NbPressed++; }
			if (playerState.PlanteL2) { algue2.SetActive(true); NbPressed++; }
			if (playerState.PlanteL3) { algue3.SetActive(true); NbPressed++; }
			break;
		case 2:
			if (playerState.PlanteK1) { algue1.SetActive(true); NbPressed++; }
			if (playerState.PlanteK2) { algue2.SetActive(true); NbPressed++; }
			if (playerState.PlanteK3) { algue3.SetActive(true); NbPressed++; }
			break;
		case 3:
			if (playerState.PlanteE1) { algue1.SetActive(true); NbPressed++; }
			if (playerState.PlanteE2) { algue2.SetActive(true); NbPressed++; }
			if (playerState.PlanteE3) { algue3.SetActive(true); NbPressed++; }
			break;
	}

	UpdateFoodAlgueUI();

	// UI si toutes les plantes sont achetées
	if (NbPressed == 3)
	{
		FoodText.gameObject.SetActive(true);
		PriceText.gameObject.SetActive(false);
		LimitText.gameObject.SetActive(false);
	}
}

    



public void BuyFoodAlguee()
{
    if (playerState.coins >= PriceFood)
    {
        playerState.coins -= PriceFood;

        switch (playerState.lvl)
        {
            case 1: // Lagoon
                if (!playerState.PlanteL1) playerState.PlanteL1 = true;
                else if (!playerState.PlanteL2) playerState.PlanteL2 = true;
                else if (!playerState.PlanteL3) playerState.PlanteL3 = true;
                break;
            case 2: // Kelp
                if (!playerState.PlanteK1) playerState.PlanteK1 = true;
                else if (!playerState.PlanteK2) playerState.PlanteK2 = true;
                else if (!playerState.PlanteK3) playerState.PlanteK3 = true;
                break;
            case 3: // Epave
                if (!playerState.PlanteE1) playerState.PlanteE1 = true;
                else if (!playerState.PlanteE2) playerState.PlanteE2 = true;
                else if (!playerState.PlanteE3) playerState.PlanteE3 = true;
                break;
        }

        UpdateCoinsUI();
        UpdatePlantesVisibility();
		if (algue3.activeSelf)
		{
			FoodText.gameObject.SetActive(true);
			PriceText.gameObject.SetActive(false);
			LimitText.gameObject.SetActive(false);
		}
	}
}

	public void BuyPack1()
	{ 
		if (playerState.coins >= PricePack1)
		{
			playerState.coins -= PricePack1;
			playerState.food += FoodPack1;
			UpdateCoinsUI();
			UpdateFoodUI();
		}
	}

	public void BuyPack2()
	{ 
		if (playerState.coins >= PricePack2)
		{
			playerState.coins -= PricePack2;
			playerState.food += FoodPack2;
			UpdateCoinsUI();
			UpdateFoodUI();
		}
	}

	public void BuyPack3()
	{ 
		if (playerState.coins >= PricePack3)
		{
			playerState.coins -= PricePack3;
			playerState.food += FoodPack3;
			UpdateCoinsUI();
			UpdateFoodUI();
		}
	}

	public void BuyPack4()
	{ 
		if (playerState.coins >= PricePack4)
		{
			playerState.coins -= PricePack4;
			playerState.food += FoodPack4;
			UpdateCoinsUI();
			UpdateFoodUI();
		}
	}
}

