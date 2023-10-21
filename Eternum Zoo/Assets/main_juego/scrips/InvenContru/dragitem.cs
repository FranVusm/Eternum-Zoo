using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
using System;
using Unity.Jobs;

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
    public bool  instancia1 = false;
    public bool instancia2 = false;
    public bool instancia3 = false;
    public bool instancia3_1 = false;
    public bool instancia4 = false;



    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        selc = FindAnyObjectByType<Seleccion>();

        
         
        if (selc.enselc)
        {
            string[] splitcell = selc.hijo_selec.name.Split('_');
            int spawn_id = int.Parse(splitcell[1]) - 1;
            switch (image.name)
            {
                case "item_bateria":
                    InstanciarYGuardarObjeto(objectToSpawn, selc.hijo_selec, selc.hijo_selec.name);
                    WeaponControl.Instance.spauner[spawn_id] = 0; //bateria = 0
                    break;
                case "item_cooler":
                    InstanciarYGuardarObjeto(objectToSpawn3, selc.hijo_selec, selc.hijo_selec.name);
                    WeaponControl.Instance.spauner[spawn_id] = 1;

                    break;
                case "item_silenciador":
                    if (selc.hijo_selec.name == "cubo_3")
                    {
                        Transform hijo4 = spawn.transform.Find("spawn_3");
                        InstanciarYGuardarObjeto(objectToSpawn4, hijo4, selc.hijo_selec.name);
                        WeaponControl.Instance.spauner[2] = 3;
                    }
                    else
                    {
                        InstanciarYGuardarObjeto(objectToSpawn4, selc.hijo_selec, selc.hijo_selec.name);
                        WeaponControl.Instance.spauner[spawn_id] = 3;
                    }

                    break;
                case "item_cargador":

                    InstanciarYGuardarObjeto(objectToSpawn2, selc.hijo_selec, selc.hijo_selec.name);
                    WeaponControl.Instance.spauner[spawn_id] = 2;
                    break;
                default:
                     
                    break;
            }
        }
        else if (!selc.enselc)
        {
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
                default:
                    break;
            }
        }
        image.raycastTarget = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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
