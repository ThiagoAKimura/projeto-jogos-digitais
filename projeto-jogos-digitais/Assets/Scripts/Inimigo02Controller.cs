using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{

    //pegar o rigidbody
    private Rigidbody2D meuRB;
    [SerializeField] private Transform posicaoTiro;

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
    }

    private void Atirando(){
        //Checar se o sprite render está visivel

        //Pegar informações dos "Filhos"
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;

        if(visivel){
            //Diminuir espera
    	    esperaTiro -= Time.deltaTime;
            if(esperaTiro <= 0){
                Instantiate(meuTiro, posicaoTiro.position, transform.rotation);

                esperaTiro = UnityEngine.Random.Range(2f,4f);
        }
        }
    }
}
