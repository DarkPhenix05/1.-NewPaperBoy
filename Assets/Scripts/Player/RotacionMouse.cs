using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionMouse : MonoBehaviour
{
    

    private void Update()
    {
        Vector3 posicionEnPantalla = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 posicionDeMouse = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direccion = posicionDeMouse - posicionEnPantalla;

        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angulo, 0));
    }
}
