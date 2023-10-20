using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class armar_reset : MonoBehaviour
{
    public GameObject arma;
    // Start is called before the first frame update
    public GameObject prefab;
    private void OnApplicationQuit()
    {
        
            // Clona el prefab para evitar cambios en el original
           // GameObject instanciaPrefab = Instantiate(arma);

            // Accede al primer hijo del prefab clonado
            //if (instanciaPrefab.transform.childCount > 0)
            //{
              //  Transform primerHijo = instanciaPrefab.transform.GetChild(0);

                // Elimina todos los hijos del primer hijo
                //foreach (Transform hijo in primerHijo)
                //{
                   // Destroy(hijo.gameObject);
                //}
            //}

            // Sale de la aplicación
            
        
    }
    }
