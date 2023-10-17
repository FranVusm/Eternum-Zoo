using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    private bool selecction = false;
    private Color colorOriginal;
    public GameObject spawn;
    private bool enselcc = false;
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
                            if (Input.GetMouseButtonDown(0))
                            {
                                print("XD");
                                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                                RaycastHit hit2;
                                if (Physics.Raycast(ray, out hit))
                                {
                                    Transform item = hit.transform;
                                    if (item.CompareTag("hola"))
                                    {
                                        
                                        InstanciarYGuardarObjeto(objectToSpawn, hijoSeleccionado);
                                    }
                                }
                            }
                                
                            
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
    private void InstanciarYGuardarObjeto(GameObject objetoPrefab, Transform spawnTransform)
    {
        Vector3 spawnPosition = spawnTransform.position;
        Quaternion rotationQuaternion = spawnTransform.rotation;
        GameObject spawnedObject = Instantiate(objetoPrefab, spawnPosition, rotationQuaternion);
        spawnedObject.transform.parent = transform;
    }
}
