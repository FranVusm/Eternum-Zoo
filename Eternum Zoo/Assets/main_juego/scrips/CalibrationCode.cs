using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class CalibrationCode : MonoBehaviour
{
    public GameObject escopeta;
    public GameObject pistola;
    public GameObject silenciador;  
    public GameObject cargador;  
    public GameObject bateria;  
    public GameObject cooler;
    public GameObject bala;  
   

    void Update()
    {
        if(escopeta.activeSelf){
            if (CheckSon(escopeta.transform.Find("arreglo_1")))
            {
                MostrarImagen(escopeta.transform.Find("arreglo_1") );
            }else{OcultarImagen(escopeta.transform.Find("arreglo_1") );}
            if (CheckSon(escopeta.transform.Find("arreglo_2")))
            {
                MostrarImagen(escopeta.transform.Find("arreglo_2") );
            }else{OcultarImagen(escopeta.transform.Find("arreglo_2") );}
            if (CheckSon(escopeta.transform.Find("arreglo_3")))
            {
                MostrarImagen(escopeta.transform.Find("arreglo_3") );
            }else{OcultarImagen(escopeta.transform.Find("arreglo_3") );}
            if (CheckSon(escopeta.transform.Find("arreglo_4")))
            {
                MostrarImagen(escopeta.transform.Find("arreglo_4") );
            }else{OcultarImagen(escopeta.transform.Find("arreglo_4") );}
            if (CheckSon(escopeta.transform.Find("spawnesco_5")))
            {
                MostrarImagen(escopeta.transform.Find("spawnesco_5") );
            }else{OcultarImagen(escopeta.transform.Find("spawnesco_5") );}
        }


        if(pistola.activeSelf){
            if (CheckSon(pistola.transform.Find("spawn_1")))
            {
                MostrarImagen(pistola.transform.Find("spawn_1") );
            }else{OcultarImagen(pistola.transform.Find("spawn_1") );}
            if (CheckSon(pistola.transform.Find("spawn_2")))
            {
                MostrarImagen(pistola.transform.Find("spawn_2") );
            }else{OcultarImagen(pistola.transform.Find("spawn_2") );}
            if (CheckSon(pistola.transform.Find("spawn_3")))
            {
                MostrarImagen(pistola.transform.Find("spawn_3") );
            }else{OcultarImagen(pistola.transform.Find("spawn_3") );}
            if (CheckSon(pistola.transform.Find("spawn_4")))
            {
                MostrarImagen(pistola.transform.Find("spawn_4") );
            }else{OcultarImagen(pistola.transform.Find("spawn_4" ));}

        }
    }
    bool CheckSon(Transform spawnpoint){
        if (spawnpoint.childCount > 0){
            return true;
        }
        else{
            return false;
        }
    }

    void MostrarImagen(Transform objetoTransform)
{
    if (objetoTransform.childCount > 0)
    {
        Transform hijo = objetoTransform.GetChild(0);

        if (hijo != null)  // Verifica si hijo no es null antes de acceder a sus propiedades
        {
            if (hijo.name == "bateria(Clone)" || hijo.name == "bateria_esco(Clone)")
            {
                bateria.SetActive(true);
            }
            else if (hijo.name == "cargador(Clone)")
            {
                cargador.SetActive(true);
            }
            else if (hijo.name == "cooler(Clone)")
            {
                cooler.SetActive(true);
            }
            else if (hijo.name == "silenciador(Clone)")
            {
                silenciador.SetActive(true);
            }
            else if (hijo.name == "balas_reserva(Clone)")
            {
                bala.SetActive(true);
            }
        }
    }
}

void OcultarImagen(Transform objetoTransform)
{
    if (objetoTransform.childCount > 0)
    {
        Transform hijo = objetoTransform.GetChild(0);

        if (hijo != null)  // Verifica si hijo no es null antes de acceder a sus propiedades
        {
            if (hijo.name == "bateria(Clone)" || hijo.name == "bateria_esco(Clone)")
            {
                bateria.SetActive(false);
            }
            else if (hijo.name == "cargador(Clone)")
            {
                cargador.SetActive(false);
            }
            else if (hijo.name == "cooler(Clone)")
            {
                cooler.SetActive(false);
            }
            else if (hijo.name == "silenciador(Clone)")
            {
                silenciador.SetActive(false);
            }
            else if (hijo.name == "balas_reserva(Clone)")
            {
                bala.SetActive(false);
            }
        }
    }
}



}
