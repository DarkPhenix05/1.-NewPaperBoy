using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Papers : MonoBehaviour
{
    private SpriteRenderer m_Renderer;
    public EstadisticasJugador estadiscasJugador;
    public UIManager uiManager;
    private AudioSource take;
    private float wait = Mathf.Infinity;

    private void Awake()
    {
        estadiscasJugador = GameObject.FindWithTag("AudioControler").GetComponent<EstadisticasJugador>();
        take = GetComponent<AudioSource>();
        m_Renderer = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        take.volume = estadiscasJugador.vol;
    }

    private void Update()
    {
        wait += Time.deltaTime;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider Player)
    {
        if (wait > 2f && Player.gameObject.CompareTag("Player"))
        {
            print("PickUP");
            take.Play();
            estadiscasJugador.periodicos = estadiscasJugador.periodicos + 5;
            estadiscasJugador.periodicosVIP = estadiscasJugador.periodicosVIP + 5;
            uiManager.ActualizarDatos();

            m_Renderer.enabled = false;
            wait = 0;
        }
    }
}
