using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private string TutorialGameplay;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void Voltar()
    {
        SceneManager.LoadScene(TutorialGameplay);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Sair do Jogo");
    }

    public void Perdoar()
    {
        SceneManager.LoadScene("Perdoar");
    }

    
    public void SeVingar()
    {
        SceneManager.LoadScene("SeVingar");
    }
}
