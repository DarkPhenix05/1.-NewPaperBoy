using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class periodico : MonoBehaviour
{
    public Rigidbody rigid;
    public float velocidad;
    public GameObject modeloPeriodico;
    private AudioSource _throw;
    private EstadisticasJugador estadisticasJugador;
    private float life;

    public float velRotacion;

    private void Awake()
    {
        estadisticasJugador = GameObject.FindWithTag("AudioControler").GetComponent<EstadisticasJugador>();
    }

    void Start()
    {
        _throw = GetComponent<AudioSource>();
        _throw.volume = estadisticasJugador.vol / 2f;
        rigid.velocity = transform.forward * velocidad;
        _throw.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;

        modeloPeriodico.transform.Rotate(velRotacion, 0, 0);
        if (life > 5f)
        {
            Destroy(gameObject);
        }
    }
}
