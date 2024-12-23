using System;
using UnityEngine;
using UnityEngine.AI;


public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] private MovementPlayer move;
    private bool estaNoChao = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
        animPlayer = GetComponent<Animator>();
        move = GetComponent<MovementPlayer>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Andando para frente
        if (Input.GetKey(KeyCode.W))
        {
            animPlayer.SetBool("Andar", true);
            animPlayer.SetBool("EstaVivo", true);
            move.Andar();
            
        }
        else
        {
            animPlayer.SetBool("Andar", false);
        }

        //Andando para tr�s
        if (Input.GetKey(KeyCode.S))
        {
            animPlayer.SetBool("AndarTras", true);
            move.Andar();
        }
        else
        {
            animPlayer.SetBool("AndarTras", false);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            move.Virar();
            animPlayer.SetBool("Andar", true);
        }

        //Correndo
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            animPlayer.SetBool("Correr", true);
        }
        else
        {
            animPlayer.SetBool("Correr", false);
        }

        //Torcida
        if(Input.GetKey(KeyCode.Q))
        {
            animPlayer.SetTrigger("Torcida");
        }

        //Interagindo
        if (Input.GetKey(KeyCode.E))
        {
            animPlayer.SetTrigger("Interagir");
        }

        //Pegando
        if (Input.GetKey(KeyCode.G))
        {
            animPlayer.SetTrigger("Pegar");
        }

        //Atacando
        if (Input.GetMouseButtonDown(0))
        {
            animPlayer.SetTrigger("Ataque");
        }

        //Pulando
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            animPlayer.SetBool("NoPiso", false);
            animPlayer.SetTrigger("Pulo");
            estaNoChao = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("espinhos"))
        {
            animPlayer.SetBool("EstaVivo", false);
            animPlayer.SetTrigger("Morte");
          
            

        
        }
    
    }


}
