using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movimentacao : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 7f;
    [SerializeField]
    private float velocidadeAngular = 2f;
    [SerializeField]
    private float forcaPulo= 25f;

    private float movimentacao = 0;
    private Rigidbody2D corpo;

    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimentacao = CrossPlatformInputManager.GetAxis("Horizontal");
        Debug.Log(movimentacao);
        
    }
    private void FixedUpdate()
    {
        corpo.velocity = new Vector2(movimentacao * velocidade, corpo.velocity.y);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && corpo.velocity.y == 0)
        {
            corpo.velocity = new Vector2(corpo.velocity.x, 0);
            corpo.AddForce(new Vector2(corpo.velocity.x, forcaPulo));
            Debug.Log("Pulou");
        }
            
    }
}
