using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilAlien : MonoBehaviour
{
    public int danio = 10; // Cantidad de daño que inflige el proyectil del Alien
     

    private void OnTriggerEnter(Collider other)
    {
        
        // Verifica si el objeto con el que colisionó tiene el tag "enemigo"
        
        if (other.CompareTag("Player"))
        {
            print("hit");
            SistemaVida sistemaVida = other.GetComponent<SistemaVida>();
            if (sistemaVida != null)
            {
                
                sistemaVida.RecibirDanio(danio);
                
            }
            // Destruye el proyectil al impactar con el enemigo
            Destroy(gameObject);


        }

        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);    
        }

           

    }
}
