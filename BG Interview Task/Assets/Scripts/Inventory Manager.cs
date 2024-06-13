using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IDropHandler
{

    public InventorySO inventorySO; // Add a reference to your InventorySO

    private void Start()
    {
        List<GameObject> ItemList = inventorySO.GetinventoryItems();

        foreach (GameObject item in ItemList)
        {
            item.SetActive(true);
        }
    }

    public void OnDrop(PointerEventData pointerData)
    {
        if (DragController.draggedObject == null) return;
        DragController.draggedObject.transform.SetParent(transform);
    }

    public void AddItem(GameObject item)
    {
        item.transform.SetParent(transform);
        inventorySO.AddItem(item);
    }

    public bool ContainsItem(GameObject item)
    {
        // Check if the item's transform is a child of this inventory's transform
        foreach (Transform child in transform)
        {
            if (child.gameObject == item)
            {
                return true;
            }
        }

        return false;
    }

    



}
