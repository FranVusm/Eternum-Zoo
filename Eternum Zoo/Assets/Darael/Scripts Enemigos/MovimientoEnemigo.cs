using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public float distanciaParaMirar = 2f; // Distancia a la que el objeto mirará al jugador

    void Update()
    {
        // Calcula la distancia entre este objeto y el jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        // Si la distancia al jugador es menor o igual a la distancia para mirar, el objeto mira al jugador
        if (distanciaAlJugador <= distanciaParaMirar)
        {
            // Obtiene la dirección hacia el jugador
            Vector3 direccionAlJugador = jugador.position - transform.position;

            // Rota el objeto para mirar hacia el jugador (ignorando la rotación en el eje Y)
            transform.rotation = Quaternion.LookRotation(new Vector3(direccionAlJugador.x, 0f, direccionAlJugador.z));
        }
    }
}
