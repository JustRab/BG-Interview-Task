using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public GameObject droppedObject;
    public EquipmentType equipmentType; 

    [SerializeField] EquipmentManager equipmentManager;
    [SerializeField] InventoryItem inventoryItem;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] EquipmentSO equipmentSO;

    [SerializeField] Item item;

    [SerializeField] private PlayerController playerController;

    void OnEnable()
    {
       playerController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
    }

    public void OnDrop(PointerEventData pointerData)
    {
        
        Debug.Log("Drop");
        if (transform.childCount == 0)
        {
                item = pointerData.pointerDrag.GetComponent<InventoryItem>().item;
                InventoryItem inventoryItem = pointerData.pointerDrag.GetComponent<InventoryItem>();
                if (item.equipmentType == equipmentType)
                {
                    droppedObject = pointerData.pointerDrag;
                    inventoryItem.parentAfterDrag = transform;
                    equipmentManager.EquipItem(item, equipmentType);
                    playerController.characterView.PlayAnimation("Rogue_attack_02");
                    playerController.isInteracting = true;
                    Debug.Log("Equipped");
                }
                else
                {
                    Debug.Log("Wrong Equipment Type");
                    droppedObject = null;
                }
        }
        else
        {
            Debug.Log("Slot is full");
        }

    }

    private void Update()
    {
        if (droppedObject != null && droppedObject.transform.parent != transform)
        {
            droppedObject = null;
            Debug.Log("Remove");
        }
    }
    
}