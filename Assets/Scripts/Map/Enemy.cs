using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyPositionX;
    public float EnemyPositionY;
    public float EnemyPositionZ;
    public float EnemySpeed = 10f;
    public float Angle1= 90f;
    public float Angle2 = 270f;


    // Start is called before the first frame update
    void Start()
    {
        EnemyPositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPositionX += EnemySpeed * Time.deltaTime;
       float move = Mathf.Clamp(EnemyPositionX, -65f, +65f);
        transform.position = new Vector3(move, transform.position.y, EnemyPositionZ);

        if (EnemyPositionX <= -60f)
        {
            EnemySpeed *= -1f;
            gameObject.transform.rotation= Quaternion.Euler(0,Angle1,0);
        }

        else if (EnemyPositionX >= 60f)
        {
            EnemySpeed *= -1f;
            gameObject.transform.rotation = Quaternion.Euler(0, Angle2, 0);
        }
    }
}
