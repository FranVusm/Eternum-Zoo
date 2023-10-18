using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;
    public float tasaDeRegeneracion = 1f; // Puntos de vida por segundo
    private WaitForSeconds esperaRegeneracion;

    private void Start()
    {
        vidaActual = vidaMaxima;
        esperaRegeneracion = new WaitForSeconds(0.5f);
        // Comienza la corutina para la regeneración de vida
        StartCoroutine(RegenerarVida());
    }

    // Corutina para regenerar la vida del jugador
    private IEnumerator RegenerarVida()
    {
        while (true)
        {
            // Si la vida actual es menor que la vida máxima, regenera 1 punto de vida
            if (vidaActual < vidaMaxima)
            {
                vidaActual += 1f;
                // Asegura que la vida actual no exceda la vida máxima
                vidaActual = Mathf.Min(vidaActual, vidaMaxima);
            }
            yield return esperaRegeneracion; // Espera 0.5 segundos antes de la próxima regeneración
        }
    }

    // Método para recibir daño
    public void RecibirDanio(float cantidadDanio)
    {
        vidaActual -= cantidadDanio;
        // Verifica si la vida ha llegado a cero o menos
        if (vidaActual <= 0f)
        {
            // Implementa aquí la lógica para cuando el jugador muere
            // Por ejemplo, mostrar un mensaje de game over, reiniciar el nivel, etc.
            // ...
            // Para este ejemplo, simplemente reiniciaremos la vida a la máxima
            Destroy(gameObject);
        }
    }
}
