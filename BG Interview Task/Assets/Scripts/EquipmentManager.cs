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

private void Update()
{
    UpdateEquipment(hoodInventorySlot, hoodSpriteRenderer, defaultHoodSprite);
    UpdateEquipment(upperClothesInventorySlot, upperClothesSpriteRenderer, defaultUpperClothesSprite);
    UpdateEquipment(lowerClothesInventorySlot, lowerClothesSpriteRenderer, defaultLowerClothesSprite);
    UpdateEquipment(weaponInventorySlot, weaponSpriteRenderer, defaultWeaponSprite);
}

private void UpdateEquipment(InventorySlot inventorySlot, SpriteRenderer spriteRenderer, Sprite defaultSprite)
{
    if (inventorySlot.droppedObject != null)
    {
        Image itemImage = inventorySlot.droppedObject.GetComponent<Image>();

        if (itemImage != null)
        {
            spriteRenderer.sprite = itemImage.sprite;
        }
        else
        {
            Debug.Log("Dropped object does not have an Image component");
        }
    }
    else
    {
        spriteRenderer.sprite = defaultSprite;
    }
}
}