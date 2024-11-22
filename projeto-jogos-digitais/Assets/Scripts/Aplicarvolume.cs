using UnityEngine;
using UnityEngine.UI;

public class Aplicarvolume : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource != null)
        {
            // Carrega o volume global e aplica ao AudioSource
            audioSource.volume = PlayerPrefs.GetFloat("VolumeGeral", 1f);
        }
    }
}
