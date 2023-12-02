using UnityEngine;

public class ArmaAlternada : MonoBehaviour
{
    public GameObject arma1;
    public GameObject arma2;

    void Start()
    {
        // Empezamos mostrando el arma 1 y ocultando el arma 2
        MostrarArma1();
        OcultarArma2();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MostrarArma1();
            OcultarArma2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MostrarArma2();
            OcultarArma1();
        }
    }

    void MostrarArma1()
    {
        arma1.SetActive(true);
    }

    void OcultarArma1()
    {
        arma1.SetActive(false);
    }

    void MostrarArma2()
    {
        arma2.SetActive(true);
    }

    void OcultarArma2()
    {
        arma2.SetActive(false);
    }
}
