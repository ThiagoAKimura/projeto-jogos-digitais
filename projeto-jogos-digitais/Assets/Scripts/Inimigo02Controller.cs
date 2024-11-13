using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{

    //pegar o rigidbody
    private Rigidbody2D meuRB;
    [SerializeField] private Transform posicaoTiro;
    [SerializeField] private float yMax = 2.5f;
    private bool possoMover = true;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        //Iniciando o movimento
        meuRB.velocity = Vector2.up * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        Atirando();

        if(transform.position.y < yMax && possoMover)
        {
            if(transform.position.x < 0f)
            {
                meuRB.velocity = new Vector2(velocidade * -1, velocidade);

                possoMover = false;
            }
            else
            {
                meuRB.velocity = new Vector2(velocidade, velocidade);

                possoMover = false;
            }
        }
        
    }

    private void Atirando(){
        //Checar se o sprite render está visivel

        //Pegar informações dos "Filhos"
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        
        if(visivel){

            var player = FindObjectOfType<PlayerController>();

            if(player){
                //Diminuir espera
                esperaTiro -= Time.deltaTime;
                if(esperaTiro <= 0){
                    var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);

                    Vector2 direcao = player.transform.position - tiro.transform.position;

                    direcao.Normalize();
                    tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                    float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

                    tiro.transform.rotation = Quaternion.Euler(0f,0f, angulo + 90);

                    esperaTiro = UnityEngine.Random.Range(11f,2f);

                    TocaTiro();
        }
        }
        }
    }
}
