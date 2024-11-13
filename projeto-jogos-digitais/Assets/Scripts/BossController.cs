using UnityEngine;
using UnityEngine.UI;

public class BossController : InimigoPai
{

    [Header("Infos Basicas")]
    [SerializeField] private string estado = "estado1"; 
    private Rigidbody2D meuRB;
    [SerializeField] private float limiteHorizontal = 6f;
    private bool direita = true;

    [Header("Infos dos tiros")]
    [SerializeField] private Transform posicaoTiro1;
    [SerializeField] private Transform posicaoTiro2;
    [SerializeField] private Transform posicaoTiro3;
    [SerializeField] private GameObject tiro1;
    [SerializeField] private GameObject tiro2;
    private float delayTiro = 1f;
    [SerializeField] private string[] estados;
    private float esperaEstados = 10f;

    [SerializeField] private UnityEngine.UI.Image imagemVida;
    [SerializeField] private int vidaMaxima = 100;



    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        vida = vidaMaxima;

        GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        TrocaEstados();

        switch(estado)
        {
            case "estado1":
                Estado1();
                break;
            case "estado2":
                Estado2();
                break;
            case "estado3":
                Estado3();
                break;
        }

        imagemVida.fillAmount = ((float)vida/(float)vidaMaxima);



        imagemVida.color = new Color32(180,(byte)(imagemVida.fillAmount * 255),0,255);

        AumentaDificuldade();
    }

    private void AumentaDificuldade()
    {
        if(vida <= vidaMaxima/2)
        {
            delayTiro = 0.6f;
        }
    }

    private void Estado3()
    {

        meuRB.velocity = Vector2.zero;

        if(esperaTiro <= 0f)
        {
            Tiro2();
            Tiro1();
            esperaTiro = delayTiro/2;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }
    }

    private void Estado2()
    {

        meuRB.velocity = Vector2.zero;

        if(esperaTiro <= 0f)
        {
            Tiro2();
            esperaTiro = delayTiro/2;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }
    }

    private void Estado1()
    {

        if(esperaTiro<= 0f)
        {
            Tiro1();
            esperaTiro = delayTiro;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }

        

        //Mexendo para esquerda e direita
        if(direita)
        {
            meuRB.velocity = new Vector2(velocidade,0f);
        }
        else
        {
            meuRB.velocity = new Vector2(-velocidade,0f);
        }

        if(transform.position.x >= limiteHorizontal)
        {
            direita = false;
        }
        else if(transform.position.x <= -limiteHorizontal)
        {
            direita = true;
        }
    }

    private void Tiro1()
    {
        GameObject tiro = Instantiate(tiro1, posicaoTiro1.position, transform.rotation);
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);
        tiro = Instantiate(tiro1, posicaoTiro2.position, transform.rotation); 
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);
        TocaTiro();
    }
    private void Tiro2()
    {
        TocaTiro();
        var player = FindObjectOfType<PlayerController>();

            if(player)
            {
                var tiro = Instantiate(tiro2, posicaoTiro3.position, transform.rotation);

                Vector2 direcao = player.transform.position - tiro.transform.position;

                direcao.Normalize();
                tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

                tiro.transform.rotation = Quaternion.Euler(0f,0f, angulo + 90);

                esperaTiro = UnityEngine.Random.Range(11f,2f);
            }
    }

    private void TrocaEstados()
    {
        if(esperaEstados <= 0f)
        {

            int indiceEstado = UnityEngine.Random.Range(0,estados.Length);

            estado = estados[indiceEstado];

            esperaEstados = 5f;
        }
        else
        {
            esperaEstados -= Time.deltaTime;
        }
    }
}

