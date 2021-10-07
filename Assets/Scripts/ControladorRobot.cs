using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorRobot : MonoBehaviour
{
    public float velocityx = 10;
    public float Salto = 25; 
    public int VecesSalta = 0;   

    public int vida=3;

    public bool ganar = false;
    
    public AudioClip[] audioClips; 

    private AudioSource audioSource;


    private Contador contador;


    private const string Moneda_1 = "MBronze";
    private const string Moneda_2 = "MPlata";
    private const string Moneda_3 = "MOro";


    private bool moverIzquierda =false;
    private bool moverDerecha =false;

    private float mytime = 0f;

    public GameObject rightBullet;
    public GameObject leftBullet;

    public GameObject rightmedio;
    public GameObject leftmedio;

    private SpriteRenderer sr;    
    private Animator animator;
    private Rigidbody2D rb;
      
    // Variables de Estado
    private const int INI= 0;
    private const int SALTA= 2;
    private const int CORRE= 1;
    private const int DESLIZA= 3;
    private const int DISPARA= 4;
    private const int CORREDISPARA= 5;
    private const int MUERE= 6;
    

          
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>();        
        contador= FindObjectOfType<Contador>();
        audioSource=GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {  if(ganar==true)
    {
        contador.PlusScore(5);
    }
        if(ganar==false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            changeAnimation(INI);  
            
            if(Input.GetKeyUp(KeyCode.Space))
            {   
                changeAnimation(SALTA);
                if(VecesSalta < 2)
                {   
                //Saltar            
                rb.AddForce(Vector2.up * Salto, ForceMode2D.Impulse); //Salto              
                VecesSalta +=1;  
                audioSource.PlayOneShot(audioClips[0]); 
                }
            }
            if(Input.GetKey(KeyCode.A) || moverIzquierda==true)
            { 
                //Correr en Reversa
                rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
                sr.flipX = true;
                changeAnimation(CORRE);
            }
            if(Input.GetKey(KeyCode.D) || moverDerecha==true)
            { 
                //Correr 
                rb.velocity = new Vector2(velocityx, rb.velocity.y); 
                sr.flipX = false;
                changeAnimation(CORRE);
            }
            if(Input.GetKey(KeyCode.S))
            { 
                //DESLIZA
                rb.velocity = new Vector2(velocityx, rb.velocity.y); 
                sr.flipX = false;
                changeAnimation(DESLIZA);
            }
            if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            { 
                //DESLIZA
                rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
                sr.flipX = true;
                changeAnimation(DESLIZA);
            }            


            if (Input.GetKey(KeyCode.X))
            {
                mytime += Time.deltaTime;
                Debug.Log(mytime);
                if (sr.color == Color.red)
                {sr.color= Color.white;}
                sr.color= Color.red;
            }
            if (Input.GetKeyUp(KeyCode.X))
            {               
                changeAnimation(DISPARA);
                if (sr.color == Color.red)
                    {sr.color= Color.white;}
                
                if (mytime >= 2)
                    {
                        
                    var bullet = sr.flipX ? rightmedio : leftmedio;
                    var position1 = new Vector2(transform.position.x,transform.position.y);
                    var rotation1 = bullet.transform.rotation;
                    Instantiate(bullet,position1,rotation1);
                    changeAnimation(DISPARA);
                    mytime = 0f;
                    }
                else
                    {
                    
                    var bullet2 = sr.flipX ? rightBullet : leftBullet;
                    var position = new Vector2(transform.position.x,transform.position.y);
                    var rotation = rightBullet.transform.rotation;
                    Instantiate(bullet2,position,rotation);
                    changeAnimation(DISPARA);
                    mytime = 0f;
                    }                    
            }  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MBronze"))
        {            
            Destroy(other.gameObject);
            contador.paraBronce(1);
            audioSource.PlayOneShot(audioClips[2]);
        }
        if(other.gameObject.CompareTag("MPlata"))
        {            
            Destroy(other.gameObject);
            contador.paraPlata(1);
             audioSource.PlayOneShot(audioClips[2]);
        }
        if(other.gameObject.CompareTag("MOro"))
        {           
            Destroy(other.gameObject);
            contador.ParaOro(1);
             audioSource.PlayOneShot(audioClips[2]);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Zombi"))
        {               
            vida -=1;   
            contador.Paravidas(-1);            
            if(vida==0)            
            {   SceneManager.LoadScene("Scene1"); 
                velocityx*=0;             
                    
                contador.PlusScore(0);
                contador.paraBronce(0);
                contador.paraPlata(0);
                contador.ParaOro(0);
                contador.Paravidas(0);
            }
            
        }
        
        if(other.gameObject.CompareTag("suelo"))
        {            
            if(VecesSalta == 2)
            {
                VecesSalta =0;
            }                        
        }
        
        if(other.gameObject.CompareTag("Llave1"))
        {
            SceneManager.LoadScene("Scene2");
        }
        if(other.gameObject.CompareTag("ganar"))
        {
            
            ganar=true;
        }

        
    }         

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }


    public void Ir_Izquierda()
    {
        moverIzquierda=true;
    }
    public void Ir_Derecha()
    {
        moverDerecha=true;
    }
    public void Detener()
    {
        moverIzquierda=false;
        moverDerecha=false;
    }

}
