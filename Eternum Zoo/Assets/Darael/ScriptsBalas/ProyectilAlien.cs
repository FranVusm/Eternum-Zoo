using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilAlien : MonoBehaviour
{
    public int danio = 10; // Cantidad de daño que inflige el proyectil del Alien


    private void OnTriggerEnter(Collider other)
    {
        
        // Verifica si el objeto con el que colisionó tiene el tag "enemigo"
        if (other.CompareTag("enemigo"))
        {
            
            Destroy(gameObject);
        }

        if (other.CompareTag("NPC"))
        {
             
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {

            SistemaVida sistemaVida = other.GetComponent<SistemaVida>();
            if (sistemaVida != null)
            {
                sistemaVida.RecibirDanio(danio);
                Destroy(gameObject);
            }
            // Destruye el proyectil al impactar con el enemigo



        }

        if (other.CompareTag("Candado"))
        {
             
            Destroy(gameObject);
        }

    }
}
