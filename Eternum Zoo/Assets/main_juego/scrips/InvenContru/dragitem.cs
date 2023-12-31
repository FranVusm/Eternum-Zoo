using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
using System;
using Unity.Jobs;
using UnityEngine.Rendering;
using System.Net;

public class dragitem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject spawn;
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public Seleccion selc;
    public GameObject imagen;
    public GameObject imagen2;
    public GameObject imagen3;
    public GameObject imagen4;
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn4;
    public GameObject objectToSpawn5;
    public GameObject objectToSpawn6;
    public GameObject objectToSpawn7;
    public bool  instancia1 = false;
    public bool instancia2 = false;
    public bool instancia3 = false;
    public bool instancia3_1 = false;
    public bool instancia4 = false;

    private Transform hijo_selec;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        selc = FindAnyObjectByType<Seleccion>();
        
        switch (image.name)
        {
            case "item_bateria":
                imagen.SetActive(true);
                break;
            case "item_cooler":
                imagen2.SetActive(true);
                break;
            case "item_silenciador":
                imagen3.SetActive(true);
                break;
            case "item_cargador":
                imagen4.SetActive(true);
                break;
            case "item_bala":
                
                break;
            case "item_can":
                print(image.name);
                break;
            default:
                break;
        }

        image.raycastTarget = false;
        
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        switch (image.name)
        {
            case "item_bateria":
                imagen.SetActive(false);
                break;
            case "item_cooler":
                imagen2.SetActive(false);
                break;
            case "item_silenciador":
                imagen3.SetActive(false);
                break;
            case "item_cargador":
                imagen4.SetActive(false);
                break;
            case "item_bala":
                break;
            case "item_can":
                break;
            case "item_estabil":
                break;
            default:
                break;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if ((hit.transform.IsChildOf(spawn.transform)) & hit.collider.tag == "Seleccionable")
            {
                
                string[] splitcell = hit.transform.name.Split('_');
                int spawn_id = int.Parse(splitcell[1]) - 1;
                
                switch (image.name)
                {
                    case "item_bateria":
                        InstanciarYGuardarObjeto(objectToSpawn, hit.transform, hit.transform.name);
                        WeaponControl.Instance.spauner[spawn_id] = 0; //bateria = 0
                        break;
                    case "item_cooler":
                        InstanciarYGuardarObjeto(objectToSpawn3, hit.transform, hit.transform.name);
                        WeaponControl.Instance.spauner[spawn_id] = 1;

                        break;
                    case "item_silenciador":
                        if (hit.transform.name == "cubo_3")
                        {
                            Transform hijo4 = spawn.transform.Find("spawn_3");
                            InstanciarYGuardarObjeto(objectToSpawn4, hijo4, hit.transform.name);
                            WeaponControl.Instance.spauner[2] = 3;
                        }
                        else
                        {
                            InstanciarYGuardarObjeto(objectToSpawn4, hit.transform, hit.transform.name);
                            WeaponControl.Instance.spauner[spawn_id] = 3;
                        }

                        break;
                    case "item_cargador":
                        InstanciarYGuardarObjeto(objectToSpawn2, hit.transform, hit.transform.name);
                        WeaponControl.Instance.spauner[spawn_id] = 2;
                        break;
                    
                        
                    case "item_bala":
                   
                        switch (hit.transform.name)
                        {
                            case "spawnesco_1":
                                Transform hijo4 = spawn.transform.Find("arreglo_1");
               
                                InstanciarYGuardarObjeto(objectToSpawn5, hijo4, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 0;
                                break;
                            case "spawnesco_2":
                                Transform hijo5 = spawn.transform.Find("arreglo_2");
                                InstanciarYGuardarObjeto(objectToSpawn5, hijo5, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 0;
                                break;
                            case "spawnesco_3":
                                Transform hijo6 = spawn.transform.Find("arreglo_3");
                                InstanciarYGuardarObjeto(objectToSpawn5, hijo6, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 0;
                                break;
                            default:
                                InstanciarYGuardarObjeto(objectToSpawn5, hit.transform, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 0;
                                break;
                        }break;
                    case "item_bateria_esco":
                        switch (hit.transform.name)
                        {
                            case "spawnesco_1":
                                Transform hijo7 = spawn.transform.Find("arreglo_1");

                                InstanciarYGuardarObjeto(objectToSpawn7, hijo7, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 1;
                                break;
                            case "spawnesco_2":
                                Transform hijo8 = spawn.transform.Find("arreglo_2");
                                InstanciarYGuardarObjeto(objectToSpawn7, hijo8, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 1;
                                break;
                            case "spawnesco_3":
                                Transform hijo9 = spawn.transform.Find("arreglo_3");
                                InstanciarYGuardarObjeto(objectToSpawn7, hijo9, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 1;
                                break;
                            default:
                                InstanciarYGuardarObjeto(objectToSpawn7, hit.transform, hit.transform.name);
                                WeaponControl.Instance.spauner_esco[spawn_id] = 1;
                                break;
                        }
                        break;
                    default:

                        break;
                }
            }
        }
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }
    public void InstanciarYGuardarObjeto(GameObject objetoPrefab, Transform spawnTransform, string hijo)
    {
        Vector3 spawnPosition = spawnTransform.position;
        Quaternion rotationQuaternion = spawnTransform.rotation;
        GameObject spawnedObject = Instantiate(objetoPrefab, spawnPosition, rotationQuaternion);
        spawnedObject.transform.parent = spawn.transform.Find(hijo);
    }

}
