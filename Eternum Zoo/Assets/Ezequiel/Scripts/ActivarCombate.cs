using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCombate : MonoBehaviour
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
    public GameObject objetoASubir11;

    private Collider miCollider;
    public GameObject spawn;

    void Start(){
        miCollider = GetComponent<Collider>();
    }

    public bool comienza = false;

    // Este método se ejecuta cuando otro collider entra en el collider de este objeto.
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el otro collider pertenece al jugador (puedes hacerlo mediante tags u otras verificaciones).
        if (other.CompareTag("Player"))
        {
           if (objetoASubir1 != null)
        {
            objetoASubir1.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir2.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir3.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir4.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir5.GetComponent<SubirObjeto>().ActivarSubida();   
            objetoASubir6.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir7.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir8.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir9.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir10.GetComponent<SubirObjeto>().ActivarSubida();
            objetoASubir11.GetComponent<SubirObjeto>().ActivarSubida();     

            spawn.SetActive(true);

            comienza = true;
            miCollider.enabled = !miCollider.enabled;
        }
        }
    }
}
