using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContBala : MonoBehaviour
{
   
    public float velocityx = 15f;


    private const string EnemyTag = "Zombi";

    private Rigidbody2D rb;

    private Contador contador;

    private Sonidoscontroller sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,5 /*Duración*/);

        contador= FindObjectOfType<Contador>();
        sound = FindObjectOfType<Sonidoscontroller>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityx, rb.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "suelo" )
        {
            Destroy(this.gameObject);
            sound.PlayShotDump();
        }
        
        if(other.gameObject.CompareTag(EnemyTag))
        {           
            Destroy(this.gameObject); 
            sound.PlayShotDump();
            
        }
    }
}
