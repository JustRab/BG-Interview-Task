using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData pointerData)
    {
        if (transform.childCount == 0) 
        {
            InventoryItem inventoryItem = pointerData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.originalParent = transform;
        }
    }
}

