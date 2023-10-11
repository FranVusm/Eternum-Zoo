using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boton_volver : MonoBehaviour
{
    // Start is called before the first frame update
    public void CambiarAScena()
    {
        // Cargar la nueva escena
        SceneManager.LoadScene("Construccion");
    }
}
