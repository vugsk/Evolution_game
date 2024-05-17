using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Camera _mainCamera;
    private Vector3 _offset;
    public Transform _defaultParent;

    private void Awake()
    {
        _mainCamera = Camera.allCameras[0];
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(eventData.position);
        newPosition.z = 0;
        transform.position = newPosition + _offset;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _offset = transform.position - _mainCamera.ScreenToWorldPoint(eventData.position);
        _defaultParent = transform.parent;
        transform.SetParent(_defaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_defaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
