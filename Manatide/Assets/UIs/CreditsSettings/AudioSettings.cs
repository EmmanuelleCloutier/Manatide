using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Le slider prend la valeur actuelle
        volumeSlider.value = GameInstance.Instance.volume;

        // Quand on bouge le slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float value)
    {
        GameInstance.Instance.SetVolume(value);
    }
}