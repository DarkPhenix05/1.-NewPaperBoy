using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    public float EnemyPositionX;
    public float EnemyPositionY;
    public float EnemyPositionZ;
    public float EnemySpeed;
    public float Angle1 = 90f;
    public float Angle2 = 270f;


    // Start is called before the first frame update
    void Start()
    {
        EnemyPositionZ = transform.position.z;
        EnemySpeed = Random.Range(-20, -10);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPositionZ += EnemySpeed * Time.deltaTime;
        float move = Mathf.Clamp(EnemyPositionZ, -480f, +480f);
        transform.position = new Vector3(transform.position.x, transform.position.y, move);

        if (EnemyPositionX <= -60f)
        {
            EnemySpeed *= -1f;
            //gameObject.transform.rotation = Quaternion.Euler(0, Angle1, 0);
        }

        else if (EnemyPositionX >= 60f)
        {
            EnemySpeed *= -1f;
            //gameObject.transform.rotation = Quaternion.Euler(0, Angle2, 0);
        }
    }
}
