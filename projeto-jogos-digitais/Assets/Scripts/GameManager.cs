using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        int qtd = FindObjectsOfType<GameManager>().Length;

        if(qtd > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PrimeiraCena()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }

    public void Menu()
    {
        StartCoroutine(PrimeiraCena());
    }
}
