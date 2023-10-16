using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    private bool selecction = false;
    private Color colorOriginal;
    public GameObject spawn;
    private bool enselcc = false;
    void Start()
    {
        Transform hijo1 = spawn.transform.Find("spawn_1");
        Transform hijo2 = spawn.transform.Find("spawn_2");
        Transform hijo3 = spawn.transform.Find("spawn_3");
        Transform hijo4 = spawn.transform.Find("spawn_4");
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
                if (hit.transform.IsChildOf(spawn.transform) && !enselcc)
                {
                    // Obtener el hijo que fue seleccionado.
                    Transform hijoSeleccionado = hit.transform;
                    
                    if (CumpleConCriterios(hijoSeleccionado))
                    {
                        // Cambiar el estado de selección.
                        selecction = !selecction;
                        enselcc = !enselcc;

                        // Cambiar el color del hijo seleccionado.
                        if (selecction)
                        {
                            hijoSeleccionado.GetComponent<Renderer>().material.color = Color.red; // Color de selección.
                            selecction = !selecction;
                        }
                       
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
