using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BajarObjeto : MonoBehaviour
{
    public float alturaDeseada = -20f; // Altura a la que va a llegar
    public float velocidadSubida = 5f; // Velocidad a la que sube

    private bool bajadaActivada  = false;

    public void ActivarBajada()
    {
        bajadaActivada  = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(bajadaActivada )
        {
            // Verifica si el objeto aún no alcanza la altura
            if (transform.position.y > alturaDeseada)
            {
                // Calcula la nueva posición
                Vector3 nuevaPosicion = transform.position - Vector3.up * velocidadSubida * Time.deltaTime;

                // Asigna la nueva posición al objeto
                transform.position = nuevaPosicion;
            }
            else
            {
                bajadaActivada  = false;
            }
        }
    }
}
