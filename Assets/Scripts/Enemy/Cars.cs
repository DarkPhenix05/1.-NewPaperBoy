using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject CarPRE;
    [SerializeField] private float cooldown;
    [SerializeField] private float time;

    private void Awake()
    {
        time = Random.Range(5, 10);
    }

    void Update()
    {
        cooldown += Time.deltaTime;


        if (cooldown >= time)
        {
            Instantiate(CarPRE, gun.position, Quaternion.identity);
            cooldown = 0;
        }
    }
}
