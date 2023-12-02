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
    public void ToCity()
    {
        SceneManager.LoadScene("NivelCiudad");
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
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void Escape()
    {
        SceneManager.LoadScene("Escape");
    }
    public void exit()
    {
        Application.Quit();
    }
}
