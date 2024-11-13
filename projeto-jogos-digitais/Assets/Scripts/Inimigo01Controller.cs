using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : InimigoPai
{

    //pegar o rigidbody
    private Rigidbody2D meuRB;
    
    [SerializeField] private Transform posicaoTiro;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        //dando velocidade pro inimigo
        meuRB.velocity = new Vector2(0f, velocidade);

        //Deixando a espera aleatoria para o primeiro tiro
        esperaTiro = UnityEngine.Random.Range(0.25f,2f);
        
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
                var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                tiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidadeTiro;

                esperaTiro = UnityEngine.Random.Range(1.5f,2f);

                TocaTiro();
        }
        }
    }
}

