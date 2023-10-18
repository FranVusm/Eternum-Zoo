using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int danio = 20; // Cantidad de daño que inflige el proyectil


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con Algo");
        // Verifica si el objeto con el que colisionó tiene el tag "enemigo"
        if (other.CompareTag("enemigo"))
        {
            Debug.Log("Colision con Enemigo");
            // Obtén el componente VidaEnemigo del enemigo y reduce su vida
            VidaEnemigo vidaEnemigo = other.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.RecibirDanio(danio);
            }

            // Destruye el proyectil al impactar con el enemigo
            Destroy(gameObject);
        }
    }
}
