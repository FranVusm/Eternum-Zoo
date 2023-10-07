using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject drop = eventData.pointerDrag;
            dragitem draggableitem = drop.GetComponent<dragitem>();
            draggableitem.parentAfterDrag = transform;
        }
    }
}
