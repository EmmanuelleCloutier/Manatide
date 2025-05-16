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
	public Transform spawnPoint;
	public TextMeshProUGUI BiomeText;


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
    
    
    [Header("Creatures")]
    public Button btnCreatures1;
    public int PriceC1;
    public GameObject prefabCreaturesType1;
    public Button btnCreatures2;
    public int PriceC2;
    public GameObject prefabCreaturesType2;
    public Button btnCreatures3;
    public int PriceC3;
    public GameObject prefabCreaturesType3;
    
    
    [Header("Decorations")]
    public Button btnDecoration1;
    public int PriceD1;
    public GameObject prefabDecorationType1;
    public Button btnDecoration2;
    public int PriceD2;
    public GameObject prefabDecorationType2;
    public Button btnDecoration3;
    public int PriceD3;
    public GameObject prefabDecorationType3;

  	[Header("Food")]
    public Button btFood;
    public int PriceFood;
	public int MaxLimit; 

	public Button btnPack1;
	public int PrincePack1;
	public Button btnPack2;
	public int PrincePack2;
	public Button btnPack3;
	public int PrincePack3;
	public Button btnPack4;
	public int PrincePack4;


	void Start()
	{
		//Ressources
  		UpdateCoinsUI();
		UpdateBiomeUI();

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
			KelpText.text = "Sold";
            btnEpaveBiome.gameObject.SetActive(true);
		}
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
	public void BuyManateType1()
	{
		if (playerState.coins >= PriceM1)
    	{
        	playerState.coins -= PriceM1;
       		Instantiate(prefabManateeType1, spawnPoint.position, Quaternion.identity);
        	UpdateCoinsUI();

        	string generatedName = nameGenerator.GenerateName();

        	ItemManatee newManatee = new ItemManatee
        	{
            	itemName = generatedName,
            	lvl = 1,
            	type = ManateeType.Type1,
            	biome = Biome.Langune
        	};
    	}
	}


 
}

