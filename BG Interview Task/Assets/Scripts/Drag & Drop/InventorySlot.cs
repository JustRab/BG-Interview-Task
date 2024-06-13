using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EquipmentType
{
    Hood,
    UpperClothes,
    LowerClothes,
    Weapon
}

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public GameObject droppedObject;
    public EquipmentType equipmentType; 


public void OnDrop(PointerEventData pointerData)
{
    Debug.Log("Drop");

    if (DragController.draggedObject.GetComponent<DragController>().equipmentType == equipmentType)
    {
        if (droppedObject != null)
        {
            droppedObject.transform.position = droppedObject.GetComponent<DragController>().originalPosition;
            droppedObject.transform.SetParent(droppedObject.GetComponent<DragController>().originalParent);
        }

        // Assign the new droppedObject
        droppedObject = DragController.draggedObject;
        droppedObject.transform.SetParent(transform);
        droppedObject.transform.position = transform.position;
    }
}

    private void Update()
    {
        if (droppedObject != null && droppedObject.transform.parent != transform)
        {
            Debug.Log("Remove");
            droppedObject = null;
        }
    }
}