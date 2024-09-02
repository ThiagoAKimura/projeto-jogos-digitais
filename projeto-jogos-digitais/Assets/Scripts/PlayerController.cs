using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public GameObject meuTiro;
    [SerializeField] float velocidade = 5f;
    private Rigidbody2D meuRB;
    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        //Atira com o botao1 do mouse ou espaco
        if (Input.GetButtonDown("Fire1")){
            Instantiate(meuTiro, transform.position, transform.rotation);
        }
            
    }
}
