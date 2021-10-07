using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    private int Score =9;
    private int B_ronze =0;
    private int P_lata =0;
    private int O_ro =0;
    private int v_idas =3;

    public Text scoreText;
    public Text nVidas;
    public Text mBronze;
    public Text mPlata;
    public Text mOro;
    
    
    void Start()
    {

        scoreText.text = " ENEMIGOS: " + Score ;
        mBronze.text = "Monedas_Bronce: " + B_ronze;
        mPlata.text = "Monedas_Plata: " + P_lata;
        mOro.text = "Monedas_Oro: " + O_ro;
        nVidas.text = "vidas: " + v_idas;
    }
    public int GetScore()
    {
        return this.Score;
    }

    public void PlusScore(int score)
    {   if(score==5)
        {
            scoreText.text = " Ganaste:, FELICITACIONES" ;
        }
        else
        {
            if(score==0)
            {
                Score=0;
            }
            this.Score-= score;  
            scoreText.text = " Score: "  +Score ;
        }       
             
    }

    public void paraBronce(int aumento)
    {
        this.B_ronze+= aumento;   
        mBronze.text = "Monedas Bronce: " + B_ronze;
        if(aumento==0)
        {
            B_ronze =0;
        }
         
           
    }

    public void  paraPlata(int aumento1)
    {
        this.P_lata+= aumento1;  
        mPlata.text = "Monedas Plata: " + P_lata;
        if(aumento1==0)
        {
            P_lata=0;
        }
        
        
    }

    public void ParaOro(int aumento2)
    {
        this.O_ro+= aumento2;        
        mOro.text = "Monedas Oro: " + O_ro;
        if(aumento2==0)
        {
            O_ro=0;
        }
          
           
    }
     public void Paravidas(int aumento4)
    {
        this.v_idas+= aumento4;        
        nVidas.text = "vidas " + v_idas;
        if(aumento4==0)
        {
            v_idas=4;
        }
          
           
    }
    
}
