using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScreenCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Camera MainCamera;
    Vector3 Target;
    public Transform Parent;
    public bool isDragging;

    void Awake()
    {
        MainCamera = Camera.allCameras[0];
    } 

    public void OnBeginDrag(PointerEventData eventData)
    {
        Target = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        Parent = transform.parent;
        isDragging = Parent.GetComponent<DropPlaceScreen>().type == FieldType.SELF_HAND;
        
        if (!isDragging)
            return;
        
        transform.SetParent(Parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts  = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
            return;

        Vector3 Position = MainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = Position + Target;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging)
            return;
            
        transform.SetParent(Parent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
