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


    IEnumerator CenaMorte()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Morte");
    }

    public void Morte()
    {
        StartCoroutine(CenaMorte());
    }

    IEnumerator CenaVitoria()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Vitoria");
    }

    public void Vitoria()
    {
        StartCoroutine(CenaVitoria());
    }

}
