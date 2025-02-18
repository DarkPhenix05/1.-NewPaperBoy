using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casas : MonoBehaviour
{
    public GameObject buzon;
    public GameObject buzonVip;



    private void Start()
    {
        int numero = Random.Range(0, 3);

        if(numero == 0)
        {
            buzon.SetActive(true);
            buzonVip.SetActive(false);
        }
        else if (numero == 1)
        {
            buzonVip.SetActive(true);
            buzon.SetActive(false);
        }
        else
        {
            buzonVip.SetActive(false);
            buzon.SetActive(false);
        }
    }
}
