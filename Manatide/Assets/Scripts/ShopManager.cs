using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

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
	public GameObject algueGroup;


	void Start()
	{
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
                return "Biome : Langune";
            case 2:
				return "Biome : Kelp";
            case 3:
                return "Biome : Épave";
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
            biome = Biome.Langune
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

        manateeManager.manateeInfoUI.RefreshUI();
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
            biome = Biome.Langune
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

        manateeManager.manateeInfoUI.RefreshUI();
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
            biome = Biome.Langune
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

        manateeManager.manateeInfoUI.RefreshUI();
        UpdateCoinsUI();

        playerState.coins -= PriceM3;
    }
}


//Food------------------------------------------------------

	public void UpdateFoodAlgueUI()
	{
		LimitText.text = NbPressed + "/3";
	}

	public void BuyFoodAlguee()
	{
		if (NbPressed <= MaxLimit)
		{
			if (playerState.coins >= PriceFood)
			{
				playerState.coins -= PriceFood;
				NbPressed++;
				UpdateCoinsUI();
				UpdateFoodAlgueUI();

				// Activer l'algue correspondante à NbPressed
				string algueName = "Algue" + (NbPressed + 2); // car Algue1 et Algue2 sont déjà actives
				Transform algue = algueGroup.transform.Find(algueName);

				if (algue != null)
				{
					algue.gameObject.SetActive(true);
				}
				else
				{
					Debug.LogWarning($"Algue '{algueName}' introuvable dans {algueGroup.name}");
				}
			}
		}
		else
		{
			FoodText.gameObject.SetActive(true);
			PriceText.gameObject.SetActive(false);
			LimitText.gameObject.SetActive(false);
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

