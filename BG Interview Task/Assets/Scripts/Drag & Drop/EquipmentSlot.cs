using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public GameObject droppedObject;
    public EquipmentType equipmentType; 
    public InventoryPool inventoryPool;

    [SerializeField] EquipmentManager equipmentManager;
    [SerializeField] InventoryItem InventoryItem;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] EquipmentSO equipmentSO;

    [SerializeField] Item item;

    public void OnDrop(PointerEventData pointerData)
    {
        
        Debug.Log("Drop");


            if (droppedObject == null && InventoryItem.draggedObject != null)
            {
                droppedObject = InventoryItem.draggedObject;
                item = droppedObject.GetComponent<InventoryItem>().item;
                if (item.equipmentType == equipmentType)
                {
                    droppedObject.transform.SetParent(transform);
                    droppedObject.transform.position = transform.position;
                    InventoryItem.draggedObject = null;
                    equipmentManager.EquipItem(item, equipmentType);
                }
                else
                {
                    Debug.Log("Wrong Equipment Type");
                    droppedObject = null;
                }
            }

    }

    private void Update()
    {
        if (droppedObject != null && droppedObject.transform.parent != transform)
        {
            switch (equipmentType)
            {
                case EquipmentType.Hood:
                    equipmentManager.hoodSpriteRenderer.sprite = equipmentManager.defaultHoodSprite;
                    break;
                case EquipmentType.UpperClothes:
                    equipmentManager.upperClothesSpriteRenderer.sprite = equipmentManager.defaultUpperClothesSprite;
                    break;
                case EquipmentType.LowerClothes:
                    equipmentManager.lowerClothesSpriteRenderer.sprite = equipmentManager.defaultLowerClothesSprite;
                    break;
                case EquipmentType.Weapon:
                    equipmentManager.weaponSpriteRenderer.sprite = equipmentManager.defaultWeaponSprite;
                    break;
            }
            droppedObject = null;
            Debug.Log("Remove");
        }
    }
    
}