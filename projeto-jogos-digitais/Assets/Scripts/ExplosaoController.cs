using UnityEngine;

public class ExplosaoController : MonoBehaviour
{

    [SerializeField] private AudioClip meuSom;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.y > -5f && transform.position.y<5f)
        {
            //Tocar audioclip da explosao
            AudioSource.PlayClipAtPoint(meuSom, Vector3.zero);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Morrendo(){
        Destroy(gameObject);
    }
}
