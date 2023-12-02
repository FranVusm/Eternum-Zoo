using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class iamgenAlter : MonoBehaviour
{
    public GameObject imagen1;
    public GameObject imagen2;
    public TextMeshProUGUI textoTMP;
    void Start()
    {
        // Empezamos mostrando la imagen 1 y ocultando la imagen 2
        MostrarImagen1();
        OcultarImagen2();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MostrarImagen1();
            OcultarImagen2();
            CambiarTexto("1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MostrarImagen2();
            OcultarImagen1();
            CambiarTexto("2");
        }
    }

    void MostrarImagen1()
    {
        imagen1.SetActive(true);
    }

    void OcultarImagen1()
    {
        imagen1.SetActive(false);
    }

    void MostrarImagen2()
    {
        imagen2.SetActive(true);
    }

    void OcultarImagen2()
    {
        imagen2.SetActive(false);
    }
    void CambiarTexto(string valor)
    {
        textoTMP.text = valor;
    }
}

