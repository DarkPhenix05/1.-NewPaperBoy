using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Menu menu;
    public Slider volSlide;
    public AudioSource mainMenuAudioSorce;
    public EstadisticasJugador estadisticasjugador;

    private void Awake()
    {
        estadisticasjugador = GameObject.FindWithTag("AudioControler").GetComponent<EstadisticasJugador>();
        
    }
    private void Start()
    {
        mainMenuAudioSorce.volume = .5f /2;
    }

    public void changeVolume()
    {
        mainMenuAudioSorce.volume = volSlide.value /2;
        estadisticasjugador.vol = volSlide.value;
    }

    public void SubmitSliderSeting()
    {
        Debug.Log(volSlide.value);
        mainMenuAudioSorce.volume = volSlide.value;
    }

}
