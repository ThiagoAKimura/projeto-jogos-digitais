using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    [SerializeField] public GameObject meuTiro;
    [SerializeField] private GameObject meuTiro2;
    [SerializeField] float velocidade = 5f;
    private Rigidbody2D meuRB;
    [SerializeField] Transform posicaoTiroPlayer;
    [SerializeField] private int vida = 3;
    [SerializeField] private GameObject explosao;

    [SerializeField] private float velocidadeTiro = 10;

    [SerializeField] private float xLimite;
    [SerializeField] private float yLimite;
    [SerializeField] private int levelTiro = 1;
    [SerializeField] private GameObject meuEscudo;
    private GameObject escudoAtual;
    private float escudoTimer = 0f;
    [SerializeField] private int qtdEscudo = 3;
    [SerializeField] private Text vidaTexto;
    [SerializeField] private Text escudoTexto;
    [SerializeField] private AudioClip somTiro;
    [SerializeField] private AudioClip somMorte;
    [SerializeField] private AudioClip somEscudo;
    [SerializeField] private AudioClip somEscudoDown;
    
    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();
        Atirando();
        CriaEscudo();
    }

    private void CriaEscudo()
    {

        escudoTexto.text = qtdEscudo.ToString();

        if (Input.GetButtonDown("Shield") && qtdEscudo > 0)
        {
            if (!escudoAtual)
            {
                escudoAtual = Instantiate(meuEscudo, transform.position, transform.rotation);

                qtdEscudo--;

                AudioSource.PlayClipAtPoint(somEscudo, Vector3.zero);
            }
        }

        if (escudoAtual)
        {
            escudoAtual.transform.position = transform.position;
            escudoTimer += Time.deltaTime;

            if (escudoTimer > 6.2f)
            {
                Destroy(escudoAtual);
                escudoTimer = 0f;
                AudioSource.PlayClipAtPoint(somEscudoDown, Vector3.zero);
            }
        }
    }


    private void Atirando()
    {
        //Atira com o botao1 do mouse ou espaco
        if (Input.GetButtonDown("Fire1"))
        {

            AudioSource.PlayClipAtPoint(somTiro, Vector3.zero);

            switch (levelTiro)
            {
                case 1:
                    CriaTrio(meuTiro, posicaoTiroPlayer.position);
                    break;
                case 2:
                    Vector3 posicao = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                    //Tiro da esquerda
                    CriaTrio(meuTiro2, posicao);
                    //Tiro da direita
                    posicao = new Vector3(transform.position.x + 0.45f, transform.position.y - 0.1f, 0f);
                    CriaTrio(meuTiro2, posicao);
                    //Break
                    break;
                case 3:
                    CriaTrio(meuTiro, posicaoTiroPlayer.position);
                    posicao = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                    //Tiro da esquerda
                    CriaTrio(meuTiro2, posicao);
                    //Tiro da direita
                    posicao = new Vector3(transform.position.x + 0.45f, transform.position.y - 0.1f, 0f);
                    CriaTrio(meuTiro2, posicao);
                    //Break
                    break;
            }
        }
    }

    private void CriaTrio(GameObject tiroCriado, Vector3 posicao)
    {
        GameObject tiro = Instantiate(tiroCriado, posicao, transform.rotation);

        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,velocidadeTiro);
    }

    private void Movendo(){
        //Pegando o input horizontal
        var horizontal = Input.GetAxis("Horizontal");
        //Pegando o input vertical
        var vertical = Input.GetAxis("Vertical");
        //Criando Vector2 para definir a velocidade do personagem
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);
        //Normalizando a velocidade
        minhaVelocidade.Normalize();
        //Passando a minha velocidade para meuRB
        meuRB.velocity = minhaVelocidade * velocidade;

        //Limitar posicao na tela
        float meuX = Mathf.Clamp(transform.position.x,-xLimite,xLimite);
        float meuY = Mathf.Clamp(transform.position.y,-yLimite,yLimite);

    	transform.position = new Vector3(meuX,meuY,transform.position.z);
    }


    public void PerdeVida(int dano){
        //Toma dano da vida
        vida -= dano;

        vidaTexto.text = vida.ToString();

        if (vida <= 0){
            Destroy(gameObject);
            
            Instantiate(explosao, transform.position, transform.rotation);

            AudioSource.PlayClipAtPoint(somMorte, new Vector3(0f,0f,-10f));

            //Carrega Menu
            var gameManager = FindObjectOfType<GameManager>();

            gameManager.Menu();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Power Up"))
        {
            if(levelTiro<3)
            {
                levelTiro++;
            }

            Destroy(other.gameObject);
        }
    }
}
