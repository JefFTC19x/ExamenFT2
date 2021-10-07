using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public float velocityx = 6;
    public int vidasenemigo = 4;

    public bool x =false;
    public bool y =false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Contador contador;
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
    }

    void Update()
    {
        contador= FindObjectOfType<Contador>();
         rb.velocity = new Vector2(velocityx,rb.velocity.y);
         x =false;
         y =false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Bala"))
        {
            vidasenemigo += -1;
        }
        if (collision.gameObject.CompareTag("Bala2"))
        {
            vidasenemigo += -2;

        }
        if(vidasenemigo==0)
        {
            Destroy(this.gameObject);
            contador.PlusScore(1);
        }
        if(vidasenemigo<0)
        {
            Destroy(this.gameObject);
            contador.PlusScore(1);
        }

        if (collision.gameObject.CompareTag("Limite"))
        {
                      
                rb.velocity = new Vector2(velocityx, rb.velocity.y);
                velocityx *= -1;

                if(sr.flipX == false)
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
                }
        }        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
                      
                rb.velocity = new Vector2(velocityx, rb.velocity.y);
                velocityx *= -1;

                if(sr.flipX == false)
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
                }
        }
        if (other.gameObject.CompareTag("Zombi"))
        {
                      
                rb.velocity = new Vector2(velocityx, rb.velocity.y);
                velocityx *= -1;

                if(sr.flipX == false)
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
                }
        }
    }

}