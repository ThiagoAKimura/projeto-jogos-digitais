using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0; // Pausa o jogo
            pausePanel.SetActive(true); // Exibe o painel de pause
        }
        else
        {
            Time.timeScale = 1; // Retoma o jogo
            pausePanel.SetActive(false); // Esconde o painel de pause
        }
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void VoltarJogo()
    {
        Time.timeScale = 1; // Retoma o jogo
        pausePanel.SetActive(false); // Esconde o painel de pause
    }
}