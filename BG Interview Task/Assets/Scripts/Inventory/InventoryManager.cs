using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(Item item)
    {
        //Find any empty slot
        for (int i=0; i < inventorySlots.Length; i++)
        {
            InventorySlot inventorySlot = inventorySlots[i];
            InventoryItem itemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, inventorySlot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventorySlot inventorySlot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, inventorySlot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();
        foreach (InventorySlot inventorySlot in inventorySlots)
        {
            InventoryItem item = inventorySlot.GetComponentInChildren<InventoryItem>();
            if (item != null)
            {
                items.Add(item.item);
            }
        }
        return items;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Items in inventory:");
            List<Item> items = GetItems();
            foreach (Item item in items)
            {
                Debug.Log(item.name);
            }
        }
    }
}
