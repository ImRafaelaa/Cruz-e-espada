using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
public class MovementPlayer : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float velocidade = 5.0f;
    [SerializeField] private float forcaPulo = 5.0f;
    private Vector3 anguloRotacao = new Vector3(0,90,0);
     private TextMeshProUGUI textoPontos;
    private TextMeshProUGUI pontoTotal;
    private float pontos = 0;
    private bool vivo = true;
    private GameObject telaGameOver, objetivos;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textoPontos = GameObject.Find("Pontos").GetComponent<TextMeshProUGUI>();
        pontoTotal = GameObject.Find("pontoTotal").GetComponent<TextMeshProUGUI>();
        pontoTotal.text = GameObject.FindGameObjectsWithTag("Esfera").Length.ToString();
        telaGameOver = GameObject.Find("Morte");
        telaGameOver.SetActive(false);
        objetivos = GameObject.Find("pegue");
        objetivos.SetActive(true);
        
    }

  public bool VerificaSePlayerEstaVivo()
    {
        return vivo;
    }
 
    //Andar
    public void Andar()
    {
        if(vivo == true)
        {
        float moveV = Input.GetAxis("Vertical");
        Vector3 direcao = moveV * transform.forward;
        rb.MovePosition(rb.position + direcao * velocidade * Time.deltaTime);
        }
        
     
    }
    //Pular
    public void Pular()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
    }

    
    //Virar
    public void Virar()
    {
        float moveH = Input.GetAxis("Horizontal");
        Quaternion rotacao = Quaternion.Euler(anguloRotacao * moveH * Time.deltaTime);
        rb.MoveRotation(rotacao * rb.rotation);
    }
    void OnCollisionEnter(Collision other)
        {

            if(other.gameObject.CompareTag("Esfera"))
            {
                other.gameObject.SetActive(false);
                //sfx.Play();
                pontos++;
                textoPontos.text = pontos.ToString();
            }
                /*else
                {
                    sfx.Stop();
                }*/
                  if(other.gameObject.CompareTag("espinhos"))
                     {
                     gameObject.SetActive(false);
                     telaGameOver.SetActive(true);
                     objetivos.SetActive(false);
        
                     }
        }

    
        

}
