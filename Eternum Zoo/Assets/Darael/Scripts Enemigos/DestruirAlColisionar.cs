using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirAlColisionar : MonoBehaviour
{
    public float tiempoAntesDeDestruccion = 3f;

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

