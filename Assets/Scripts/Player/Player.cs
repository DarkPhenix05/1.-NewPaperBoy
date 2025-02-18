using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public EstadisticasJugador estadiscasJugador;
    public UIManager uiManager;
    public float velocidadNormal;
    public float velocidadMaxima;
    public float velocidadMinima;
    public Rigidbody rigid;
    public Animator anim;
    public GameObject ModeloJugador;
    private AudioSource sonidoChoque;
    public bool JuegoTerminado;
    public bool choque;


    public Transform disparador;
    public GameObject periodicoPre;
    public GameObject periodicoVIP;

    public AudioSource musica;


    private void Awake()
    {
        estadiscasJugador= GameObject.FindWithTag("AudioControler").GetComponent<EstadisticasJugador>();
        sonidoChoque = GetComponent<AudioSource>();
        musica.volume = estadiscasJugador.vol;
    }

    void Start()
    {
        sonidoChoque.volume = estadiscasJugador.vol / 2f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Colision Detectada");
        if (collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Periodico")
        {
            print("En el suelo");
        }
        else
        {
            if (!choque)
            {
                print("Choque");
                
                rigid.velocity = Vector3.zero;
                anim.SetBool("choque", true);
                choque = true;
                uiManager.QuitarCorazones();
                 sonidoChoque.Play();
            }
        }
    }

    public void RestablecerChoque()
    {
        StartCoroutine(RestableciendoChoque());
    }
    
    IEnumerator RestableciendoChoque()
    {
        yield return new WaitForSeconds(1.5f);

        ModeloJugador.SetActive(false);
        anim.SetBool("choque", false);

        yield return new WaitForSeconds(.5f);
        transform.position = new Vector3(1.3f, 0.06998616f, transform.position.z -40f);
        choque = false;
        ModeloJugador.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {   if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.Pause();
        }

        if (!JuegoTerminado)
        {
            if (!choque && uiManager.pause == false)
            {
                if (Input.GetButtonDown("Fire1") && estadiscasJugador.periodicos > 0)
                {
                    Instantiate(periodicoPre,disparador.position,disparador.transform.rotation);
                    estadiscasJugador.periodicos--;
                    uiManager.ActualizarDatos();
                }

                if (Input.GetButtonDown("Fire2") && estadiscasJugador.periodicosVIP > 0)
                {
                    Instantiate(periodicoVIP, disparador.position, disparador.transform.rotation);
                    estadiscasJugador.periodicosVIP--;
                    uiManager.ActualizarDatos();
                }

                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");

                anim.SetFloat("x", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("y", Input.GetAxisRaw("Vertical"));

                if (vertical > 0)
                {
                    anim.SetBool("velocidadMaxima", true);
                    
                    Vector3 direction = (transform.forward * 1 + transform.right * horizontal).normalized;
                    rigid.velocity = direction * velocidadMaxima;
                }
                else if (vertical < 0)
                {
                    anim.SetBool("velocidadMinima", true);
                    Vector3 direction = (transform.forward * 1 + transform.right * horizontal).normalized;
                    rigid.velocity = direction * velocidadMinima;
                }
                else if (horizontal != 0)
                {
                    Vector3 direction = (transform.forward * 1 + transform.right * horizontal).normalized;
                    rigid.velocity = direction * velocidadNormal;
                }
                else
                {
                    anim.SetBool("velocidadMaxima", false);
                    anim.SetBool("velocidadMinima", false);
                    rigid.velocity = Vector3.forward * velocidadNormal;
                }
            }
        }
    }
}
