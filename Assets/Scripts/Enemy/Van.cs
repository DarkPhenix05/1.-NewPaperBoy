using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.Unicode;

public class Van : MonoBehaviour
{
    [SerializeField] private Transform gunVan;
    [SerializeField] private GameObject TirePRE;
    [SerializeField] private float cooldown;
    [SerializeField] private float time;

    private void Awake()
    {
        time = Random.Range(2,5);
    }

    void Update()
    {
        cooldown += Time.deltaTime;


        if (cooldown >= time)
        {
            Instantiate(TirePRE, gunVan.position, Quaternion.identity);
            cooldown = 0;
        }
    }
}
