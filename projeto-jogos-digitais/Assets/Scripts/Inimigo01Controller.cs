using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{

    //pegar o rigidbody
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = -3f;
    [SerializeField] public GameObject meuTiro;
    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        //dando velocidade pro inimigo
        meuRB.velocity = new Vector2(0f, velocidade);
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(meuTiro, transform.position, transform.rotation);
    }
}

