using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static Menu instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Storry ()
    {
        SceneManager.LoadScene("Story");
    }

    public void Vol (float vol)
    {
        audioMixer.SetFloat("Volume", vol);
    }

    public void Quit()
    {

    }
}
