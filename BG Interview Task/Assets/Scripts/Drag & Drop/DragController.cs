using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject draggedObject;
    public EquipmentType equipmentType; 

    public Vector3 originalPosition;
    public Transform originalParent;
    private CanvasGroup cGroup;
    private Transform dragParentTransform;

    private void Start() 
    {
        cGroup = GetComponent<CanvasGroup>();
        dragParentTransform = GameObject.FindGameObjectWithTag("ObjectDraggerParent").transform;
    }

    public void OnBeginDrag(PointerEventData pointerData)
    {
        Debug.Log("StartDrag");
        draggedObject = this.gameObject;

        originalPosition = this.transform.position;
        originalParent = this.transform.parent;
        this.transform.SetParent(dragParentTransform);

        cGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData pointerData)
    {
        this.transform.position = Input.mousePosition;
    }

public void OnEndDrag(PointerEventData pointerData)
{
    Debug.Log("EndDrag");
    draggedObject = null;

    cGroup.blocksRaycasts = true;
    if (this.transform.parent == dragParentTransform)
    {
        this.transform.position = originalPosition;
        this.transform.SetParent(originalParent);
    }
}
}