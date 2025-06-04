using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BiomeUIManager : MonoBehaviour
{
    [Header("Biome Buttons")] 
    public Button Langune;
    public Button Kelp;
    public Button Epave;
    
    

    [Header("Ressources")] 
    public ShopManager shopManager;
    public PlayerState playerState;
    
    

    void Start()
    {
        Langune.onClick.AddListener(GoToLangune);
        Kelp.onClick.AddListener(GoToKelp);
        Epave.onClick.AddListener(GoToEpave);
    }

    public void GoToMainMenu()
    {
        playerState.lvl = 1;
        SaveAndLoadBiome("LVL_MainMenu");
    }

    public void GoToLangune()
    {
        playerState.lvl = 1; // Langune
        SaveAndLoadBiome("LVL_Langune");
    }

    void GoToKelp()
    {
        if (playerState.BiomeKelp)
        {
            playerState.lvl = 2;
            SaveAndLoadBiome("LVL_Kelp");
        }
        else
        {
            Debug.Log("Tu dois acheter le biome Kelp d'abord !");
        }
    }

    void GoToEpave()
    {
        if (playerState.BiomeEpave)
        {
            playerState.lvl = 3;
            SaveAndLoadBiome("LVL_Epave");
        }
        else
        {
            Debug.Log("Tu dois acheter le biome Épave d'abord !");
        }
    }

    void SaveAndLoadBiome(string sceneName)
    {
        shopManager.SaveGame(); 
        SceneManager.LoadScene(sceneName);
    }
}