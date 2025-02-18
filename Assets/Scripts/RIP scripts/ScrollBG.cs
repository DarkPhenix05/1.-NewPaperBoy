using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float scrollSpeed;
    public Vector3 startPosition;
    public GameObject bloquePrefab;
    void FixedUpdate()
    {
        transform.position = transform.position + Vector3.forward * scrollSpeed * Time.deltaTime;
        if (transform.position.z <= -95.9f)
        {
            Instantiate(bloquePrefab, startPosition, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
