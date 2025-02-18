using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public Vector3[] posiciones;
    public GameObject[] casas;
    private void Start()
    {
        for (int i = 0; i< posiciones.Length; i++)
        {
            int casa = Random.Range(0, casas.Length);
            Instantiate(casas[casa], posiciones[i], Quaternion.identity);
        }
    }
}
