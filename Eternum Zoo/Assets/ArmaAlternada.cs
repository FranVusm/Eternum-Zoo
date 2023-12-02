using UnityEngine;
using UnityEngine.UI;

public class ArmaAlternada : MonoBehaviour
{
    public GameObject arma1;
    public GameObject arma2;

    public Image[] imagenesArma1; // Imágenes asociadas al arma 1
    public Image[] imagenesArma2; // Imágenes asociadas al arma 2

    void Start()
    {
        MostrarArma1();
        OcultarArma2();
        CambiarColorImagenes(imagenesArma1, Color.green);
        CambiarColorImagenes(imagenesArma2, Color.red);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MostrarArma1();
            OcultarArma2();
            CambiarColorImagenes(imagenesArma1, Color.green);
            CambiarColorImagenes(imagenesArma2, Color.red);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MostrarArma2();
            OcultarArma1();
            CambiarColorImagenes(imagenesArma1, Color.red);
            CambiarColorImagenes(imagenesArma2, Color.green);
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

    // Función para cambiar el color de las imágenes
    void CambiarColorImagenes(Image[] imagenes, Color color)
    {
        foreach (Image imagen in imagenes)
        {
            imagen.color = color;
        }
    }
}

