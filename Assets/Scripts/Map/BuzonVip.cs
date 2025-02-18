using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzonVip : MonoBehaviour
{
    UIManager uiManager;
    public EstadisticasJugador estadisticasJugador;
    public GameObject efecto;
    public GameObject hit;
    private AudioSource sonidoDelivery;

    private bool first = true;


    private void Awake()
    {
        sonidoDelivery = GetComponent<AudioSource>();
        uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        estadisticasJugador = GameObject.FindWithTag("AudioControler").GetComponent<EstadisticasJugador>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (first == true)
        {
            print("Buzon");
            if (collision.gameObject.CompareTag("Periodico") && estadisticasJugador.score > 0)
            {
                estadisticasJugador.score -= 500;
                uiManager.ActualizarDatos();
                efecto.SetActive(false);
                hit.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Periodico") && estadisticasJugador.score < 0)
            {
                estadisticasJugador.score = 0;
                uiManager.ActualizarDatos();
                efecto.SetActive(false);
                hit.SetActive(false);
            }
            if (collision.gameObject.CompareTag("PeriodicoVIP"))
            {
                estadisticasJugador.score += 500;
                uiManager.ActualizarDatos();
                efecto.SetActive(false);
                hit.SetActive(true);
                sonidoDelivery.Play();
            }
            first = false;
        }

    }
}

