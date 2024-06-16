using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public Vector3 originalPosition;
    public Transform originalParent;
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;
    public Item item;
    public EquipmentType equipmentType;

    public InventoryManager inventoryManager;

    public void OnBeginDrag(PointerEventData pointerData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData pointerData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData pointerData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    public void InitialiseItem(Item newItem) {
        image = GetComponent<Image>();
        equipmentType = newItem.equipmentType;
        inventoryManager = FindObjectOfType<InventoryManager>();
        item = newItem;
        image.sprite = newItem.itemSprite;
    }
}