using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance;

    public float volume = 0.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Charge le volume sauvegardé, sinon 0.5
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);

        // Applique le volume
        AudioListener.volume = volume;
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        AudioListener.volume = volume;

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}