using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirObjeto : MonoBehaviour
{
    public float alturaDeseada = 13f; // Altura a la que va a llegar
    public float velocidadSubida = 5f; // Velocidad a la que sube

    private bool subidaActivada = false;

    public void ActivarSubida()
    {
        subidaActivada = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(subidaActivada)
        {
            // Verifica si el objeto aún no alcanza la altura
            if (transform.position.y < alturaDeseada)
            {
                // Calcula la nueva posición
                Vector3 nuevaPosicion = transform.position + Vector3.up * velocidadSubida * Time.deltaTime;

                // Asigna la nueva posición al objeto
                transform.position = nuevaPosicion;
            }
            else
            {
                subidaActivada = false;
            }
        }
    }
}
