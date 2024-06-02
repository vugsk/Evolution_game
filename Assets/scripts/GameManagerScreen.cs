using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<Card> EnemyDeck, PlayerDeck, EnemyField, PlayerField, EnemyHand, PlayerHand;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();

        EnemyField = new List<Card>();
        PlayerField  = new List<Card>();
        EnemyHand  = new List<Card>();
        PlayerHand   = new List<Card>();
    }

    List<Card> GiveDeckCard()
    {
        List<Card> deck = new List<Card>();
        for (int i = 0; i < 25; i++)
            deck.Add(ManagerCard.cards[Random.Range(0, ManagerCard.cards.Count)]);
        return deck;
    }
}

public class GameManagerScreen : MonoBehaviour
{
    public Game game;
    public Transform EnemyHand, PlayerHand;
    public GameObject CardP;

    public void Start()
    {
        game = new Game();

        GiveHandCard(game.EnemyDeck, EnemyHand);
        GiveHandCard(game.PlayerDeck, PlayerHand);
    }

    public void GiveHandCard(List<Card> deck, Transform parent)
    {
        int i = 0;
        while(i < 4)
            GiveCardToHand(deck, parent);
    }

    public void GiveCardToHand(List<Card> deck, Transform parent)
    {
        if (deck.Count  ==  0)
            return;

        Card card  = deck[0];

        GameObject go = Instantiate(CardP, parent, false);

        if (parent == EnemyHand)
            go.GetComponent<CardInfoScreen>().HideCardInfo(card);
        else
            go.GetComponent<CardInfoScreen>().ShowCardInfo(card);

        deck.RemoveAt(0);
    }
}
