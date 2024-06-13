using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventory SO", menuName = "ScriptableObjects/StartingInventory", order = 1)]
public class InventorySO : ScriptableObject
{
    private List<GameObject> inventoryItems;

    public List<GameObject> GetinventoryItems()
    {
        return inventoryItems;
    }

    public void SetinventoryItems(List<GameObject> items)
    {
        inventoryItems = items;
    }

    public void AddItem(GameObject item)
    {
        //Add the item to the list
        inventoryItems.Add(item);
    }

    public bool ContainsItem(GameObject item)
    {
        return inventoryItems.Contains(item);
    }

    public void RemoveItem(GameObject item)
    {
        //Remove the item from the list
        inventoryItems.Remove(item);
    }

    public void ClearItems()
    {
        //Disable all items
        foreach (GameObject item in inventoryItems)
        {
            item.SetActive(false);
        }
    }
}
