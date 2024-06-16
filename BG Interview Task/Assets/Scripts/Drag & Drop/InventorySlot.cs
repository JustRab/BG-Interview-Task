using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryItem item;
    public EquipmentManager equipmentManager;
    public EquipmentSO equipmentSO;
    public PlayerController playerController;

    public void OnDrop(PointerEventData pointerData)
    {
        if (transform.childCount == 0) 
        {
            InventoryItem inventoryItem = pointerData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            item = null;
        }
        else
        {
            item = transform.GetChild(0).GetComponent<InventoryItem>();
        }
        if (item != null)
        {
            switch (item.equipmentType)
            {
                case EquipmentType.Hood:
                    if (equipmentSO.EquipedHood == item.item)
                    {
                        equipmentManager.EquipItem(equipmentManager.defaultHood, EquipmentType.Hood);
                        if (item.item.healthBonus != 0)
                        {
                            playerController.maxHealth -= item.item.healthBonus;
                        }
                        if (item.item.attackBonus != 0)
                        {
                            playerController.attackDamage -= item.item.attackBonus;
                        }
                        if (item.item.speedBonus != 0)
                        {
                            playerController.speed -= item.item.speedBonus;
                        }
                    }
                    break;
                case EquipmentType.UpperClothes:
                    if (equipmentSO.EquipedUpperClothes == item.item)
                    {
                        equipmentManager.EquipItem(equipmentManager.defaultUpperClothes, EquipmentType.UpperClothes);
                        if (item.item.healthBonus != 0)
                        {
                            playerController.maxHealth -= item.item.healthBonus;
                        }
                        if (item.item.attackBonus != 0)
                        {
                            playerController.attackDamage -= item.item.attackBonus;
                        }
                        if (item.item.speedBonus != 0)
                        {
                            playerController.speed -= item.item.speedBonus;
                        }
                    }
                    break;
                case EquipmentType.LowerClothes:
                    if (equipmentSO.EquipedLowerClothes == item.item)
                    {
                        equipmentManager.EquipItem(equipmentManager.defaultLowerClothes, EquipmentType.LowerClothes);
                        if (item.item.healthBonus != 0)
                        {
                            playerController.maxHealth -= item.item.healthBonus;
                        }
                        if (item.item.attackBonus != 0)
                        {
                            playerController.attackDamage -= item.item.attackBonus;
                        }
                        if (item.item.speedBonus != 0)
                        {
                            playerController.speed -= item.item.speedBonus;
                        }
                    }
                    break;
                case EquipmentType.Weapon:
                    if (equipmentSO.EquipedWeapon == item.item)
                    {
                        equipmentManager.EquipItem(equipmentManager.defaultWeapon, EquipmentType.Weapon);
                        if (item.item.healthBonus != 0)
                        {
                            playerController.maxHealth -= item.item.healthBonus;
                        }
                        if (item.item.attackBonus != 0)
                        {
                            playerController.attackDamage -= item.item.attackBonus;
                        }
                        if (item.item.speedBonus != 0)
                        {
                            playerController.speed -= item.item.speedBonus;
                        }
                    }
                    break;
            }
        }
    }
}

