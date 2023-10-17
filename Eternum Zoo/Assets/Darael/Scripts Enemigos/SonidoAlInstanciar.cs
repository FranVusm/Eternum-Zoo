using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAlInstanciar : MonoBehaviour
{
    public AudioClip sonido; // Asigna tu clip de sonido a través del Editor de Unity

    void Awake()
    {
        if (sonido != null)
        {
            // Reproduce el sonido cuando el objeto se instancia
            AudioSource.PlayClipAtPoint(sonido, transform.position);
        }
        else
        {
            Debug.LogWarning("No se ha asignado ningún clip de sonido al objeto.");
        }
    }
}

