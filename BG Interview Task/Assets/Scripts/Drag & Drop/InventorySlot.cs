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

    [SerializeField] EquipmentManager equipmentManager;
    [SerializeField] EquipmentSO equipmentSO; // Add a reference to your EquipmentSO

    private void Start()
    {
        equipmentManager = GameObject.FindGameObjectWithTag("EquipmentManager").GetComponent<EquipmentManager>();
    }

    public void OnDrop(PointerEventData pointerData)
    {
        Debug.Log("Drop");

        if (!droppedObject && DragController.draggedObject.GetComponent<DragController>().equipmentType == equipmentType)
        {
            droppedObject = DragController.draggedObject;
            droppedObject.transform.SetParent(transform);
            droppedObject.transform.position = transform.position;
            equipmentManager.EquipItem(droppedObject, equipmentType);
        }
    }

    private void Update()
    {
        if (droppedObject != null && droppedObject.transform.parent != transform)
        {
            switch (equipmentType)
            {
                case EquipmentType.Hood:
                    equipmentSO.EquipedHood = null;
                    equipmentManager.hoodSpriteRenderer.sprite = equipmentManager.defaultHoodSprite;
                    break;
                case EquipmentType.UpperClothes:
                    equipmentSO.EquipedUpperClothes = null;
                    equipmentManager.upperClothesSpriteRenderer.sprite = equipmentManager.defaultUpperClothesSprite;
                    break;
                case EquipmentType.LowerClothes:
                    equipmentSO.EquipedLowerClothes = null;
                    equipmentManager.lowerClothesSpriteRenderer.sprite = equipmentManager.defaultLowerClothesSprite;
                    break;
                case EquipmentType.Weapon:
                    equipmentSO.EquipedWeapon = null;
                    equipmentManager.weaponSpriteRenderer.sprite = equipmentManager.defaultWeaponSprite;
                    break;
            }
            equipmentManager.inventorySO.AddItem(droppedObject);
            Debug.Log("Remove");
            droppedObject = null;
        }
    }
    
}