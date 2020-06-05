using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public float Speed;
    public float Force;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // FixedUpdate -> roda a cada coisa fisica que acontece no jogo
    void FixedUpdate(){
        MovementX();
        Jump();
    }

    void MovementX(){
        //Verifica se a tecla D ou seta direita está apertada e muda a velocidade
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2d.velocity = new Vector2(Speed, 0);
            animator.Play("PersonagemCorrendo");
            spriteRenderer.flipX = false;
        } 

        //Verifica se a tecla A ou seta esquerda está apertada e muda a velocidade
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2d.velocity = new Vector2(-Speed, 0);
            animator.Play("PersonagemCorrendo");
            spriteRenderer.flipX = true;

        } else {
            animator.Play("PersonagemParado");
        } 
    }

    void Jump(){
        //Caso o espaço ou W esteja apertada, muda a velocidade em Y, fazendo ele "subir"
        if (Input.GetKey("space") || Input.GetKey("w")){
            rb2d.velocity = new Vector2(rb2d.velocity.x, Force);
        }
    }
}
