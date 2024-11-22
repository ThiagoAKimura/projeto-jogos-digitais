using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float velocidade;
    [SerializeField] protected int vida;
    [SerializeField] protected GameObject explosao;
    [SerializeField] protected float esperaTiro = 1f;
    [SerializeField] protected GameObject meuTiro;
    [SerializeField] protected float velocidadeTiro = 5f;
    [SerializeField] protected int pontos = 10;
    [SerializeField] protected GameObject powerUp;
    [SerializeField] protected GameObject powerUpBomba;
    [SerializeField] protected GameObject powerUpBateria;
    [SerializeField] protected float itemRate = 0.9f;
    [SerializeField] protected float itemRateBomba = 0.5f;
    [SerializeField] protected float itemRateEscudo = 0.5f;
    [SerializeField] protected AudioClip somTiro;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void TocaTiro()
    {
        AudioSource.PlayClipAtPoint(somTiro, Vector3.zero);
    }

    public void PerdeVida(int dano)
    {
        if(transform.position.y < 5f)
        {
            vida -= dano;

            if (vida <= 0 )
            {
                Destroy(gameObject);
                
                Instantiate(explosao, transform.position, transform.rotation);


                if(powerUp)
                {
                    DropaItem();
                }

                var gerador = FindObjectOfType<GeradorInimigos>();
                //gerador.DiminuiQuantidade();
                if(gerador)
                {
                gerador.GanhaPontos(pontos);
                }
            }
        }        
    }

    private void OnDestroy()
    {
        var gerador = FindObjectOfType<GeradorInimigos>();
        if(gerador)
        {
            gerador.DiminuiQuantidade();
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Destruidor"))
        {
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);
            //var gerador = FindObjectOfType<GeradorInimigos>();
            //gerador.DiminuiQuantidade();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Jogador"))
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
            other.gameObject.GetComponent<PlayerController>().PerdeVida(1);
            DropaItem();
        }
    }

    public void DropaItem()
    {

        float chance = UnityEngine.Random.Range(0f,1f);

        if(chance > itemRate)
        {
            GameObject pU = Instantiate(powerUp, transform.position, transform.rotation);
            Destroy(pU, 5.2f);
            Vector2 dir = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
            pU.GetComponent<Rigidbody2D>().velocity = dir;
        }
        if(chance > itemRateBomba)
        {
            GameObject Bomb = Instantiate(powerUpBomba, transform.position, transform.rotation);
            Destroy(Bomb, 5.2f);
            Vector2 dirBomb = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
            Bomb.GetComponent<Rigidbody2D>().velocity = dirBomb;
            
        }
        if(chance > itemRateEscudo)
        {
            GameObject Shield = Instantiate(powerUpBateria, transform.position, transform.rotation);
            Destroy(Shield, 5.2f);
            Vector2 dirBateria = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
            Shield.GetComponent<Rigidbody2D>().velocity = dirBateria;
        }
    }
}
