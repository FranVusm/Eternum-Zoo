using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mesa_usu : MonoBehaviour
{
    public void CambiarAScena()
    {
        // Cargar la nueva escena
        SceneManager.LoadScene("Trabajo_arma");
    }
}
