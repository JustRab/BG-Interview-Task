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

    [SerializeField] public int timesUpdated = 0;
    public TextMeshProUGUI updateText;

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
                timesUpdated++;
                UpdateEquipmentSprite(item, hoodSpriteRenderer, hoodEquipmentSlot);
                break;
            case EquipmentType.UpperClothes:
                timesUpdated++;
                UpdateEquipmentSprite(item, upperClothesSpriteRenderer, upperClothesEquipmentSlot);
                break;
            case EquipmentType.LowerClothes:
                timesUpdated++;
                UpdateEquipmentSprite(item, lowerClothesSpriteRenderer, lowerClothesEquipmentSlot);
                break;
            case EquipmentType.Weapon:
                timesUpdated++;
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
            if (EquipmentSlot.droppedObject != null)
            {
                EquipmentSlot.droppedObject.transform.SetParent(EquipmentSlot.transform);

                // Set the size, position, and anchors of the droppedObject
                RectTransform rectTransform = EquipmentSlot.droppedObject.GetComponent<RectTransform>();
                if (rectTransform != null && EquipmentSlot.droppedObject.GetComponent<Canvas>() == null)
                {
                    rectTransform.sizeDelta = new Vector2(150, 150); // Set width and height to 150
                    rectTransform.anchorMin = new Vector2(0.5f, 0.5f); // Anchor to the center of the parent
                    rectTransform.anchorMax = new Vector2(0.5f, 0.5f); // Anchor to the center of the parent
                    rectTransform.pivot = new Vector2(0.5f, 0.5f); // Set the pivot to the center of the droppedObject
                    rectTransform.anchoredPosition = Vector2.zero; // Center the droppedObject
                }
            }
            timesUpdated++;
        }
        else if (itemSprite == null)
        {
            Debug.Log("No Sprite");
            spriteRenderer.sprite = null;
            timesUpdated++;
        }
}
            public void Update()
    {
        updateText.text = "Times Updated: " + timesUpdated + equipmentSO.EquipedHood + equipmentSO.EquipedUpperClothes + equipmentSO.EquipedLowerClothes + equipmentSO.EquipedWeapon;
    }
}


