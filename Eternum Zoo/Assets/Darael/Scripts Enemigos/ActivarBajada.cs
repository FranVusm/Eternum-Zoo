using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBajada : MonoBehaviour
{
    public GameObject objetoASubir1;
    public GameObject objetoASubir2;
    public GameObject objetoASubir3;
    public GameObject objetoASubir4;
    public GameObject objetoASubir5;
    public GameObject objetoASubir6;
    public GameObject objetoASubir7;
    public GameObject objetoASubir8;
    public GameObject objetoASubir9;
    public GameObject objetoASubir10;

    public VidaJefe vida;

    void Update(){

        vida = FindAnyObjectByType<VidaJefe>();

        //Debug.Log(vida.vidaActual);

        if (vida.vidaActual < 1)
        {
            Bajada();
        }

    }


    // Este método se ejecuta cuando otro collider entra en el collider de este objeto.


    void Bajada()
    {
        // Verificamos si el otro collider pertenece al jugador (puedes hacerlo mediante tags u otras verificaciones).

            Debug.Log("bajando objetos");

            objetoASubir1.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir2.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir3.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir4.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir5.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir6.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir7.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir8.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir9.GetComponent<BajarObjeto>().ActivarBajada();
            objetoASubir10.GetComponent<BajarObjeto>().ActivarBajada();
        
    }
}
