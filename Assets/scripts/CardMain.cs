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
        new CardInfo("Водоплавающие",  "Может быть атаковано только хищником со свойством водоплавающие",  "Sprites/card_test"),
        new CardInfo("Быстрое", "Когда атаковано хищником, бросьте кубик. Если 4, 5, 6 - не съедено.", "UI/card"),
        new CardInfo("Мимикрия",  "Когда первый раз за ход атакованно хищником, должно перенаправлено атаку на другое свое животное.",  "UI/card"),
        new CardInfo("Большой",   "Может быть атаковано только хищникос со свойством большой.",   "UI/card"),
        new CardInfo("Топотун",   "Может использовать в каждом раунде свою фазу питания - уничтожить одну 'красную' на кормовой базе.",   "Assets/UI/card"),
        new CardInfo("Ядовитый",   "Хищник съевший это животное в фазу вымирания текущего хода погибает",   "Assets/UI/card"),
        new CardInfo("Отбрасывание хвоста",   "Когда животное атаковано хищником, поместить в сбррос карту этого или другого имеющегося у животного свойства - остается в живых. Хищник получает одну синию",   "Assets/UI/card"),
        new CardInfo("Спячка",   "Можно использовать в свою фазу питания - животное считается накормленным. Нельзя использовать два хода подряд и в последнйи ход игры.",   "Assets/UI/card"),
        new CardInfo("Падальщики",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Симбиоз",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Пиратство",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Камуфляж",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Норное",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Сотрудничество",   "Description  3",   "Assets/UI/card"),
        new CardInfo("Острое зрение",   "Description  3",   "Assets/UI/card"),
        // new CardInfo("паразит",   "Description  3",   "Assets/UI/card"),
        // new CardInfo("Средний",   "Description  3",   "Assets/UI/card")
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
            ManagerCard.cards.Add(new Card(card));
    }
}
