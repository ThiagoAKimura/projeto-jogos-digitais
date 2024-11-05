using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float velocidade;
    [SerializeField] protected int vida;
    [SerializeField] protected GameObject explosao;
    protected float esperaTiro = 1f;
    [SerializeField] protected GameObject meuTiro;
    [SerializeField] protected float velocidadeTiro = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerdeVida(int dano){
        vida -= dano;

        if (vida <= 0 ){
            Destroy(gameObject);
            
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }
}
