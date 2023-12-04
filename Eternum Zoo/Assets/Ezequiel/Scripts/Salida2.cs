using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida2 : MonoBehaviour
{
    // Este método se ejecuta cuando otro collider entra en el collider de este objeto.
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el otro collider pertenece al jugador (puedes hacerlo mediante tags u otras verificaciones).
        if (other.CompareTag("Player"))
        {
            // Cambiamos a la escena deseada. En este ejemplo, cambiamos a la escena "NuevaEscena".
            SceneManager.LoadScene("Escape");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}