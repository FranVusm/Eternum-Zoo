using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida1 : MonoBehaviour
{
    // Este método se ejecuta cuando otro collider entra en el collider de este objeto.
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el otro collider pertenece al jugador (puedes hacerlo mediante tags u otras verificaciones).
        if (other.CompareTag("Player"))
        {
            // Cambiamos a la escena deseada. En este ejemplo, cambiamos a la escena "NuevaEscena".
            SceneManager.LoadScene("NivelBaseMilitar");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}