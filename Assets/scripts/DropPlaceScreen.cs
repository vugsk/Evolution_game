using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    SELF_HAND,
    SELF_FIELD,
    ENEMY_HAND,
    ENEMY_FIELD,
}

public class DropPlaceScreen : MonoBehaviour, IDropHandler
{
    public FieldType type;

   public void OnDrop(PointerEventData eventData)
   {
        if (type != FieldType.SELF_FIELD)
            return;

        MoveScreenCard card = eventData.pointerDrag.GetComponent<MoveScreenCard>();

        if (card)
            card.Parent = transform;
   }
}
