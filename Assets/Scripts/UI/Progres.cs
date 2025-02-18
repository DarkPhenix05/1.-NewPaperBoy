using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progres : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject slider;

    private void Start()
    {
        slider.GetComponent<Slider>().value= 0f;
    }

    private void Update()
    {
        slider.GetComponent<Slider>().value = player.transform.position.z;
    }

}
