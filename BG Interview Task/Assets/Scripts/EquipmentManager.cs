using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentManager : MonoBehaviour
{
    public EquipmentSlot hoodEquipmentSlot; // EquipmentSlot for the hood
    public EquipmentSlot upperClothesEquipmentSlot; // EquipmentSlot for the clothes
    public EquipmentSlot lowerClothesEquipmentSlot; // EquipmentSlot for the clothes
    public EquipmentSlot weaponEquipmentSlot; // EquipmentSlot for the weapon

    public SpriteRenderer hoodSpriteRenderer; // SpriteRenderer for the hood
    public SpriteRenderer upperClothesSpriteRenderer; // SpriteRenderer for the clothes
    public SpriteRenderer lowerClothesSpriteRenderer; // SpriteRenderer for the clothes
    public SpriteRenderer weaponSpriteRenderer; // SpriteRenderer for the weapon

    [SerializeField] public Item defaultHood; // Default hood
    [SerializeField] public Item defaultUpperClothes; // Default clothes
    [SerializeField] public Item defaultLowerClothes; // Default clothes
    [SerializeField] public Item defaultWeapon; // Default weapon

    public Sprite defaultHoodSprite; // Default hood sprite
    public Sprite defaultUpperClothesSprite; // Default clothes sprite
    public Sprite defaultLowerClothesSprite; // Default clothes sprite
    public Sprite defaultWeaponSprite; // Default weapon sprite

    public EquipmentSO equipmentSO; // The EquipmentSO object
    public InventorySO inventorySO; // The InventorySO object

    private void Start()
    {
        // Set the default equipment
        equipmentSO.EquipedHood = defaultHood;
        equipmentSO.EquipedUpperClothes = defaultUpperClothes;
        equipmentSO.EquipedLowerClothes = defaultLowerClothes;
        equipmentSO.EquipedWeapon = defaultWeapon;

        // Update the equipment sprites
        UpdateEquipmentSprite(equipmentSO.EquipedHood, hoodSpriteRenderer, hoodEquipmentSlot);
        UpdateEquipmentSprite(equipmentSO.EquipedUpperClothes, upperClothesSpriteRenderer, upperClothesEquipmentSlot);
        UpdateEquipmentSprite(equipmentSO.EquipedLowerClothes, lowerClothesSpriteRenderer, lowerClothesEquipmentSlot);
        UpdateEquipmentSprite(equipmentSO.EquipedWeapon, weaponSpriteRenderer, weaponEquipmentSlot);
    }

    public void EquipItem(Item item, EquipmentType equipmentType)
    {
        switch (equipmentType)
        {
            case EquipmentType.Hood:
                equipmentSO.EquipedHood = item;
                UpdateEquipmentSprite(item, hoodSpriteRenderer, hoodEquipmentSlot);
                break;
            case EquipmentType.UpperClothes:
                equipmentSO.EquipedUpperClothes = item;
                UpdateEquipmentSprite(item, upperClothesSpriteRenderer, upperClothesEquipmentSlot);
                break;
            case EquipmentType.LowerClothes:
                equipmentSO.EquipedLowerClothes = item;
                UpdateEquipmentSprite(item, lowerClothesSpriteRenderer, lowerClothesEquipmentSlot);
                break;
            case EquipmentType.Weapon:
                
                equipmentSO.EquipedWeapon = item;
                UpdateEquipmentSprite(item, weaponSpriteRenderer, weaponEquipmentSlot);
                break;
        }
    }

public void UpdateEquipmentSprite(Item equipment, SpriteRenderer spriteRenderer, EquipmentSlot EquipmentSlot)
{
        Sprite itemSprite = equipment.itemSprite;
        if (itemSprite != null)
        {
            spriteRenderer.sprite = itemSprite;
        }
        else if (itemSprite == null)
        {
            Debug.Log("No Sprite");
            spriteRenderer.sprite = null;
        }
}
}


