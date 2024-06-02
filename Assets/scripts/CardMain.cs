using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CardInfo
{
    public string name;
    public string description;
    public string path;

    public CardInfo(string name, string description, string path)
    {
        this.name  = name;
        this.description  = description;
        this.path  = path;
    }
}

class InfoCards
{
    public static List<CardInfo> listCard = new List<CardInfo>()
    {
        new CardInfo("Большой",  "Description  1",  "Sprites/card_test"),
        new CardInfo("Маленький", "Description  2", "UI/card"),
        new CardInfo("Средний",  "Description  3",  "UI/card"),
        new CardInfo("Средний",   "Description  3",   "UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Средний",   "Description  3",   "Assets/UI/card")
    };
}


public struct Card
{
    public string name;
    public string description;
    public Sprite logo;

    public Card(string name, string description, string path)
    {
        this.name = name;
        this.description = description;
        this.logo = Resources.Load<Sprite>(path);
    }

    public Card(CardInfo card)
    {
        this.name = card.name;
        this.description = card.description;
        this.logo = Resources.Load<Sprite>(card.path);
    }

}




public class ManagerCard
{
    public static List<Card> cards = new List<Card>();
}



public class CardMain : MonoBehaviour
{
    public void Awake()
    {
        foreach (var card in InfoCards.listCard)
        {
            ManagerCard.cards.Add(new Card(card));
        }
    }
}
