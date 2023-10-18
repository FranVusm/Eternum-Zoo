using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
using System;
using Unity.Jobs;

public class dragitem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject spawn;
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public Seleccion selc;
     
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn4;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        selc = FindAnyObjectByType<Seleccion>();
        if (selc.enselc)
        {
            switch (image.name)
            {
                case "item_bateria":
                    InstanciarYGuardarObjeto(objectToSpawn, selc.hijo_selec, selc.hijo_selec.name);
                        break;
                case "item_cooler":
                    InstanciarYGuardarObjeto(objectToSpawn3, selc.hijo_selec, selc.hijo_selec.name);
                    print(image.name);
                    break;
                case "item_silenciador":
                    if(selc.hijo_selec.name == "cubo")
                    {
                        Transform hijo4 = spawn.transform.Find("spawn_3");
                        InstanciarYGuardarObjeto(objectToSpawn4, hijo4, selc.hijo_selec.name);
                    }
                    else
                    {
                        InstanciarYGuardarObjeto(objectToSpawn4, selc.hijo_selec, selc.hijo_selec.name);
                    }
                    
                    break;
                case "item_cargador":

                    InstanciarYGuardarObjeto(objectToSpawn2, selc.hijo_selec, selc.hijo_selec.name);
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
