using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScreen : MonoBehaviour
{
    public Card SelfCard;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public Image Logo;

    public void ShowCardInfo(Card card)
    {
        SelfCard = card;
        Name.text = card.name;
        Description.text = card.description;
        Logo.sprite = card.logo;
        Logo.preserveAspect = true;
    }

    public void HideCardInfo(Card card)
    {
        SelfCard = card;
        Name.text  = "";
        Description.text  =  "";
        Logo.sprite   =  null;
    }

    public void Start()
    {
        ShowCardInfo(ManagerCard.cards[transform.GetSiblingIndex()]);
    }

}
