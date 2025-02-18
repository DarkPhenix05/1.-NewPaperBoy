using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireRight : MonoBehaviour
{
    public Rigidbody rigid;
    public float velocidad;
    public GameObject modelorueda;
    public float velRotacion;

    public float life;

    void Start()
    {
        transform.Rotate(0f, 90f, 0f);
        rigid.velocity = transform.forward * velocidad;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;

        modelorueda.transform.Rotate(velRotacion, 0f, 0f);

        if (life > 10f)
        {
            Destroy(gameObject);
        }
    }
}
