using UnityEngine;
using UnityEngine.UI;

public class ControladorDeVolume : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        // Carrega o volume salvo e ajusta o slider
        float volume = PlayerPrefs.GetFloat("VolumeGeral", 1f);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
            volumeSlider.onValueChanged.AddListener(AtualizarVolume);
        }
    }

    public void AtualizarVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
        // Salva o volume no PlayerPrefs para que seja persistente
        PlayerPrefs.SetFloat("VolumeGeral", volume);
    }
}
