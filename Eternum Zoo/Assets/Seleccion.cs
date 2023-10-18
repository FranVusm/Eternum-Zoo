using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public bool selecction = false;
    public bool enselc = false;
    public  Color colorOriginal;
    public GameObject spawn;
    public Transform hijo_selec;
    private Transform hijo_selec1;
    public GameObject objectToSpawn;
    void Start()
    {
        Transform hijo1 = spawn.transform.Find("spawn_1");
        Renderer hijoRenderer = hijo1.GetComponent<Renderer>();
        Color colorOriginal = hijoRenderer.material.color;
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                // Verificar si el objeto golpeado es una instancia del prefab.
                if ((hit.transform.IsChildOf(spawn.transform)) || hit.collider.tag == "No Seleccionable")
                {
                    // Obtener el hijo que fue seleccionado.
                    Transform hijoSeleccionado = hit.transform;
                    hijo_selec = hijoSeleccionado;

                    if (CumpleConCriterios(hijoSeleccionado))
                    {
                        // Cambiar el estado de selección.
                        selecction = !selecction;
                        enselc = !enselc;
                        hijo_selec = hijoSeleccionado;
                        hijo_selec1 = hijoSeleccionado;

                        // Cambiar el color del hijo seleccionado.
                        if (selecction)
                        {
                            hijoSeleccionado.GetComponent<Renderer>().material.color = Color.red; // Color de selección.
                             
                        }
                    }
                    if (!CumpleConCriterios(hijoSeleccionado) & enselc) 
                    {

                        hijo_selec1.GetComponent<Renderer>().material.color = colorOriginal;
                        selecction = !selecction;
                        enselc = !enselc;

                    }
                }
               
            }
        }
    }

    private bool CumpleConCriterios(Transform hijo)
    {
        return hijo.CompareTag("Seleccionable");
    }
    
}
