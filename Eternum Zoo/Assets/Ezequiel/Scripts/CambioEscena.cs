using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToGame()
    {
        SceneManager.LoadScene("NivelZoo");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Pantalla Inicio");
    }
    public void ToInfo()
    {
        SceneManager.LoadScene("Instrucciones");
    }
    public void ToAssets()
    {
        SceneManager.LoadScene("AssetsUsados");
    }
    public void exit()
    {
        Application.Quit();
    }
}
