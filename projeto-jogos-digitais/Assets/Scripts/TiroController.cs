using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{

    private Rigidbody2D meuRB;
    [SerializeField] private GameObject impacto;
    // Start is called before the first frame update
    void Start()
    {
        //Usando RigidBody2D
        meuRB = GetComponent<Rigidbody2D>();

        //Indo para cima
        //meuRB.velocity = new Vector2(0f, vel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Inimigo")){
            collision.GetComponent<InimigoPai>().PerdeVida(1);
        }

        else if(collision.CompareTag("Jogador")){
            collision.GetComponent<PlayerController>().PerdeVida(1);
        }

        Destroy(gameObject);

        Instantiate(impacto, transform.position, transform.rotation);
    }
}
