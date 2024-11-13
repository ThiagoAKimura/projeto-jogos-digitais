using UnityEngine;
using UnityEngine.UI;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private int pontos = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private float esperaInimigos = 0f;
    [SerializeField] private float tempoEspera = 5f;
    [SerializeField] private int baseLevel = 100;
    [SerializeField] private int qtdInimigos = 0;
    [SerializeField] private GameObject bossAnimation;
    private bool animacaoBoss = false;
    [SerializeField] private Text pontosTexto;
    [SerializeField] private AudioClip musicaBoss;
    [SerializeField] private AudioSource musica;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level <10)
        {
            GeraInimigos();
        }
        else
        {
            GeraBoss();
        }
    }

    public void GeraBoss()
    {

        if(qtdInimigos <=0 && tempoEspera > 0)
        {
            tempoEspera -= Time.deltaTime;
        }

        if(!animacaoBoss && tempoEspera <= 0)
        {
            GameObject animBoss = Instantiate(bossAnimation,Vector3.zero,transform.rotation);

            animacaoBoss = true;

            musica.clip = musicaBoss;
            musica.Play();
        }
    }

    public void GanhaPontos(int pontos)
    {
        this.pontos += pontos * level;

        pontosTexto.text = this.pontos.ToString();

        if(this.pontos > baseLevel)
        {
            level++;

            baseLevel *= 2;
        }
    }

    public void DiminuiQuantidade()
    {
        qtdInimigos--;
    }

    private bool ChecaPosicao(Vector3 posicao, Vector3 size)
    {
        Collider2D hit = Physics2D.OverlapBox(posicao, size, 0f);

        if(hit != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GeraInimigos(){
        if(esperaInimigos > 0 && qtdInimigos <= 0)
        {
            esperaInimigos -= Time.deltaTime;
        }

        if(esperaInimigos <= 0f && qtdInimigos <= 0)
        {

            int quantidade = level * 4;

            int tentativas = 0;

            while(qtdInimigos < quantidade )
            {

                tentativas++;

                if(tentativas>200)
                {
                    break;
                }

                GameObject inimigoCriado;

                float chance = UnityEngine.Random.Range(0f, level);

                if(chance> 2f)
                {
                    inimigoCriado = inimigos[1];
                }
                else
                {
                    inimigoCriado = inimigos[0];
                }

                Vector3 posicao = new Vector3(UnityEngine.Random.Range(-8f,8f), UnityEngine.Random.Range(6f, 17f), 0f);

                bool colisao = ChecaPosicao(posicao, inimigoCriado.transform.localScale);

                if(colisao)
                {
                    continue;
                } 

                Instantiate(inimigoCriado, posicao, transform.rotation);
                qtdInimigos++;

                esperaInimigos = tempoEspera;
            }     
        }
    }
}
