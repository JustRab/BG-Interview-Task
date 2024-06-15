using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject draggedObject;

    public Vector3 originalPosition;
    public Transform originalParent;
    private CanvasGroup cGroup;
    private Transform dragParentTransform;
    public Transform startingParent;
    public Image image;

    public Item item;

    public InventoryManager inventoryManager;

    public void OnBeginDrag(PointerEventData pointerData)
    {
        image.raycastTarget = false;
        draggedObject = this.gameObject;
        originalPosition = this.transform.position;
        originalParent = this.transform.parent;
        this.transform.SetParent(dragParentTransform.root);

        cGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData pointerData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData pointerData)
    {
        image.raycastTarget = true;
        cGroup.blocksRaycasts = true;
        if (this.transform.parent == dragParentTransform)
        {
            this.transform.position = originalPosition;
            this.transform.SetParent(originalParent);
            inventoryManager.AddItem(item);
        }
    }

    public void InitialiseItem(Item newItem) {
        cGroup = GetComponent<CanvasGroup>();
        dragParentTransform = GameObject.FindGameObjectWithTag("ObjectDraggerParent").transform;
        image = GetComponent<Image>();
        inventoryManager = FindObjectOfType<InventoryManager>();
        item = newItem;
        image.sprite = newItem.itemSprite;
    }
}