using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPool : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData pointerData)
    {
        if (InventoryItem.draggedObject == null) return;
        InventoryItem.draggedObject.transform.SetParent(transform);
    }

}