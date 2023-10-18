using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverseAlJugador : MonoBehaviour
{
    public Transform jugador; // El objeto Transform del jugador al que nos moveremos
    public float velocidad = 10f; // Velocidad a la que nos moveremos hacia el jugador
    public float distanciaAcercarMaxima = 10f;
    public float distanciaAcercarMínima = 1f;
    void Update()
    {
        // Verificar si el jugador está a una distancia mayor o igual a 50 unidades
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador <= distanciaAcercarMaxima && distanciaAlJugador >= distanciaAcercarMínima)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;

            // Mover el objeto hacia el jugador a la velocidad especificada
            transform.Translate(direccionAlJugador * velocidad * Time.deltaTime);
        }
    }
}
