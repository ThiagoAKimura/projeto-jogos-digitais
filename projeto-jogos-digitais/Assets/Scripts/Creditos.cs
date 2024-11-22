using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Menu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CenaMenu()
    {
        yield return new WaitForSeconds(11f);
        SceneManager.LoadScene("Menu");
    }

    public void Menu()
    {
        StartCoroutine(CenaMenu());
    }
}
