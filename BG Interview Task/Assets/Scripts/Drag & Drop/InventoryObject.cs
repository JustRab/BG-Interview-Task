using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryObject : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData pointerData)
    {
        if (DragController.draggedObject == null) return;
        DragController.draggedObject.transform.SetParent(transform);
    }
}