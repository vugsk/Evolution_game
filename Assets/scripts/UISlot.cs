using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        UIItem item = eventData.pointerDrag.GetComponent<UIItem>();
        if (item)
            item._defaultParent = transform;
    }
}
