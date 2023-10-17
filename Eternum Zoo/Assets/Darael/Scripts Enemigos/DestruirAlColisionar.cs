using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirAlColisionar : MonoBehaviour
{
    public float tiempoAntesDeDestruccion = 3f;

    void OnCollisionEnter(Collision collision)
    {
        // Destruye el objeto al tocar cualquier cosa
        Destroy(gameObject);
    }

    void Awake()
    {
        // Invoca la función DestruirDespuesDeTiempo después de un cierto tiempo
        Invoke("DestruirDespuesDeTiempo", tiempoAntesDeDestruccion);
    }

    void DestruirDespuesDeTiempo()
    {
        // Destruye el objeto después de un cierto tiempo
        Destroy(gameObject);
    }
}

