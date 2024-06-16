using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    public PlayerController playerController;

    public void OnEnable()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void PickupItem(int id)
    {
        if(playerController.money >= itemsToPickup[id].itemPrice)
        {
            playerController.money -= itemsToPickup[id].itemPrice;
            inventoryManager.AddItem(itemsToPickup[id]);
        }
    }
}
