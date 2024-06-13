using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public InventorySlot hoodInventorySlot; // InventorySlot for the hood
    public InventorySlot upperClothesInventorySlot; // InventorySlot for the clothes
    public InventorySlot lowerClothesInventorySlot; // InventorySlot for the clothes
    public InventorySlot weaponInventorySlot; // InventorySlot for the weapon

    public SpriteRenderer hoodSpriteRenderer; // SpriteRenderer for the hood
    public SpriteRenderer upperClothesSpriteRenderer; // SpriteRenderer for the clothes
    public SpriteRenderer lowerClothesSpriteRenderer; // SpriteRenderer for the clothes
    public SpriteRenderer weaponSpriteRenderer; // SpriteRenderer for the weapon

    public Sprite defaultHoodSprite; // Default sprite for the hood
    public Sprite defaultUpperClothesSprite; // Default sprite for the clothes
    public Sprite defaultLowerClothesSprite; // Default sprite for the clothes
    public Sprite defaultWeaponSprite; // Default sprite for the weapon
    public EquipmentSO equipmentSO; // The EquipmentSO object
    public InventorySO inventorySO; // The InventorySO object

    private void Start()
    {
        // Update the equipment visuals
        UpdateEquipment();

        switch (equipmentSO.EquipedHood)
        {
            case null:
                hoodInventorySlot.droppedObject = null;
                break;
            default:
                hoodInventorySlot.droppedObject = equipmentSO.EquipedHood;
                break;
        }

        switch (equipmentSO.EquipedUpperClothes)
        {
            case null:
                upperClothesInventorySlot.droppedObject = null;
                break;
            default:
                upperClothesInventorySlot.droppedObject = equipmentSO.EquipedUpperClothes;
                break;
        }

        switch (equipmentSO.EquipedLowerClothes)
        {
            case null:
                lowerClothesInventorySlot.droppedObject = null;
                break;
            default:
                lowerClothesInventorySlot.droppedObject = equipmentSO.EquipedLowerClothes;
                break;
        }

        switch (equipmentSO.EquipedWeapon)
        {
            case null:
                weaponInventorySlot.droppedObject = null;
                break;
            default:
                weaponInventorySlot.droppedObject = equipmentSO.EquipedWeapon;
                break;
        }

    }

    public void EquipItem(GameObject item, EquipmentType equipmentType)
    {
        switch (equipmentType)
        {
            case EquipmentType.Hood:
                equipmentSO.EquipedHood = item;
                inventorySO.RemoveItem(item);
                break;
            case EquipmentType.UpperClothes:
                equipmentSO.EquipedUpperClothes = item;
                inventorySO.RemoveItem(item);
                break;
            case EquipmentType.LowerClothes:
                equipmentSO.EquipedLowerClothes = item;
                inventorySO.RemoveItem(item);
                break;
            case EquipmentType.Weapon:
                equipmentSO.EquipedWeapon = item;
                inventorySO.RemoveItem(item);
                break;
        }

    // Then call UpdateEquipment to update the visuals
        UpdateEquipment();
    }

    private void UpdateEquipment()
    {
        // Update the SpriteRenderers based on the current equipment
        UpdateEquipmentSprite(equipmentSO.EquipedHood, hoodSpriteRenderer, defaultHoodSprite, hoodInventorySlot);
        UpdateEquipmentSprite(equipmentSO.EquipedUpperClothes, upperClothesSpriteRenderer, defaultUpperClothesSprite, upperClothesInventorySlot);
        UpdateEquipmentSprite(equipmentSO.EquipedLowerClothes, lowerClothesSpriteRenderer, defaultLowerClothesSprite, lowerClothesInventorySlot);
        UpdateEquipmentSprite(equipmentSO.EquipedWeapon, weaponSpriteRenderer, defaultWeaponSprite, weaponInventorySlot);
        
    }

private void UpdateEquipmentSprite(GameObject equipment, SpriteRenderer spriteRenderer, Sprite defaultSprite, InventorySlot inventorySlot)
{
    if (equipment != null)
    {
        Image itemImage = equipment.GetComponent<Image>();

        if (itemImage != null)
        {
            spriteRenderer.sprite = itemImage.sprite;
            inventorySO.RemoveItem(equipment);
            inventorySlot.droppedObject = equipment;
            inventorySlot.droppedObject.transform.SetParent(inventorySlot.transform);

            // Set the size, position, and anchors of the droppedObject
            RectTransform rectTransform = inventorySlot.droppedObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(150, 150); // Set width and height to 150
                rectTransform.anchorMin = new Vector2(0.5f, 0.5f); // Anchor to the center of the parent
                rectTransform.anchorMax = new Vector2(0.5f, 0.5f); // Anchor to the center of the parent
                rectTransform.pivot = new Vector2(0.5f, 0.5f); // Set the pivot to the center of the droppedObject
                rectTransform.anchoredPosition = Vector2.zero; // Center the droppedObject
            }
        }
        else
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }
    else
    {
        spriteRenderer.sprite = defaultSprite;
    }
}
}