using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    [Header("Interfaz de usuario")]
    Player player;
    public EstadisticasJugador estadisticasJugador;
    public GameObject corazonPrefab;
    public Transform corazonPadre;
    public TextMeshProUGUI periodicos;
    public TextMeshProUGUI periodicosVip;
    public TextMeshProUGUI score;
    public TextMeshProUGUI maxscore;
    public TextMeshProUGUI endscore;

    [Header("Panel Game Over")]
    public GameObject panelGameover;

    [Header("Panel Final")]
    public GameObject panelRepetir;

    [Header("Panel Game Pause")]
    public GameObject panelPause;
    public bool pause= false;


    private void Awake()
    {
        estadisticasJugador = GameObject.FindWithTag("AudioControler").GetComponent<EstadisticasJugador>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        StartCoroutine(InstancearCorazones());
        periodicos.text = "x" + estadisticasJugador.periodicos;
        periodicosVip.text = "x" + estadisticasJugador.periodicosVIP;
        score.text = "Score: " + estadisticasJugador.score + " pts";
        Time.timeScale = 1;
    }

    IEnumerator InstancearCorazones()
    {
        for (int i = 0; i < estadisticasJugador.vidas; i++)
        {
            //Corazon nuevoCorazon = corazonPrefab.GetComponent<Corazon>();
            //nuevoCorazon.corazonLleno.fillAmount = 0;

            Instantiate(corazonPrefab, corazonPadre, false);

            //yield return new WaitForSeconds(.01f);

            for (float e = 0f; e < 1f; e += 0.05f)
            {
                
                //corazonPadre.GetChild(i).GetComponent<Corazon>().corazonLleno.fillAmount = e;

                yield return new WaitForSeconds(0.01f);
            }

            corazonPadre.GetChild(i).GetComponent<Corazon>().corazonLleno.fillAmount = 1;
            yield return new WaitForSeconds(.1f);
            Time.timeScale = 1;
        }
    }

    public void QuitarCorazones()
    {
        StartCoroutine(QuitandoCorazones());
        Time.timeScale = 1;
    }
    IEnumerator QuitandoCorazones()
    {
        int indexCorazon = estadisticasJugador.vidas - 1;

        for (float e = 1f; e > 0f; e -= 0.05f)
        {

            corazonPadre.GetChild(indexCorazon).GetComponent<Corazon>().corazonLleno.fillAmount = e;

            yield return new WaitForSeconds(0.01f);
        }

        corazonPadre.GetChild(indexCorazon).GetComponent<Corazon>().corazonLleno.fillAmount = 0;
        estadisticasJugador.vidas--;

        if (estadisticasJugador.vidas <= 0)
        {
            panelGameover.SetActive(true);
        }
        else
        {
            player.RestablecerChoque();
        }
        Time.timeScale = 1;
    }
    public void ActualizarDatos()
    {  
        periodicos.text = "x" + estadisticasJugador.periodicos;
        periodicosVip.text = "x" + estadisticasJugador.periodicosVIP;
        score.text = "Score: " + estadisticasJugador.score + " pts";
        Time.timeScale = 1;
    }

    public void Final()
    {

    }

    public void RepetirJuego()
    {
        SceneManager.LoadScene("Story");
        estadisticasJugador.score = 0;
        estadisticasJugador.vidas = 3;
        estadisticasJugador.periodicos = 0;
        estadisticasJugador.periodicosVIP = 0;
        Time.timeScale = 1;
    }

    public void SalirJuego()
    {
        print("Salir del Juego");
        Application.Quit();
    }

    public void MaxScore()
    {
        if (estadisticasJugador.score < estadisticasJugador.maxscore)
        {
            maxscore.text = "Max Score:" + estadisticasJugador.maxscore + "pts";
            Time.timeScale = 1;
        }
        else
        {
            maxscore.text = "NEW Max Score:" +  estadisticasJugador.score + " pts";
            estadisticasJugador.maxscore = estadisticasJugador.score;
            Time.timeScale = 1;
        }
    }

    public void Score()
    {
            endscore.text = "Score:"  + estadisticasJugador.score + " pts";
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }
    public void Play()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }
}
