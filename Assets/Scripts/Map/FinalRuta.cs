using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRuta : MonoBehaviour
{
    public Player jugador;
    public UIManager uiManager;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            jugador.JuegoTerminado = true;
            uiManager.panelRepetir.SetActive(true);
            Invoke("AnimacionFinal", .1f);
            print("Colision Final detectada");
        }
        else
        {
            print("in end");
        }
        uiManager.MaxScore();
        uiManager.Score();
    }
  
    public void AnimacionFinal()
    {
        jugador.anim.SetBool("juegoTerminado", true);

    }
}
