using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public string nombreJugador = "player"; // Nombre del objeto del jugador
    public float distanciaParaMirar = 2f; // Distancia a la que el objeto mirará al jugador

    void Update()
    {
        
        // Buscar el objeto del jugador por su nombre
        GameObject jugadorObject = GameObject.Find(nombreJugador);

        // Si se encontró el objeto del jugador
        if (jugadorObject != null)
        {
            // Calcula la distancia entre este objeto y el jugador
            float distanciaAlJugador = Vector3.Distance(transform.position, jugadorObject.transform.position);

            // Si la distancia al jugador es menor o igual a la distancia para mirar, el objeto mira al jugador
            if (distanciaAlJugador <= distanciaParaMirar)
            {
                // Obtiene la dirección hacia el jugador
                Vector3 direccionAlJugador = jugadorObject.transform.position - transform.position;

                // Rota el objeto para mirar hacia el jugador (ignorando la rotación en el eje Y)
                transform.rotation = Quaternion.LookRotation(new Vector3(direccionAlJugador.x, 0f, direccionAlJugador.z));
            }
        }
        else
        {
            // Maneja el caso en el que el objeto del jugador no se ha encontrado
            Debug.LogError("No se encontró el objeto del jugador con el nombre: " + nombreJugador);
        }
    }
}