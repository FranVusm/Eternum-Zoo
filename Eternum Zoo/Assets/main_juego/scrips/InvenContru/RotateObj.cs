using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    private bool isRotating = false;
    private float rotationSpeed = 3.5f; // Velocidad de rotación del objeto.
    public KeyCode centro;
    private Quaternion rotacionInicial;
    private void OnMouseDown()
    {
        isRotating = true;
    }

    private void OnMouseUp()
    {
        isRotating = false;
    }
    private void Start()
    {
        rotacionInicial = transform.rotation;
    }

    private void Update()
    {
        // Rotar el objeto si isRotating es true.
        if (isRotating)
        {
            // Obtener el movimiento del mouse en los ejes X y Y.
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Aplicar la rotación al objeto basado en el movimiento del mouse.
            transform.Rotate(Vector3.up * mouseX * rotationSpeed);
            transform.Rotate(Vector3.left * mouseY * rotationSpeed);
        }
        if(Input.GetKeyDown(centro)) {
            transform.rotation = rotacionInicial;
        }
    }
}
