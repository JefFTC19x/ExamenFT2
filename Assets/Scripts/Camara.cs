using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
     public Transform Jugador;
     public Transform background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {           
        var y  = Jugador.position.y;// + 10;
        var x  = Jugador.position.x;
        transform.position = new Vector3(x,y,transform.position.z);  

        background.position = new Vector3(transform.position.x,transform.position.y,background.position.z);   
    }
}