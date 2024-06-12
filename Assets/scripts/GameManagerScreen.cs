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
        for (int i = 0; i < 15; i++)
            deck.Add(ManagerCard.cards[Random.Range(0, ManagerCard.cards.Count)]);
        return deck;
    }
}

public class GameManagerScreen : MonoBehaviour
{
    public Game game;
    public Transform EnemyHand, PlayerHand;
    public GameObject CardP;

    int turn, turnTime = 30;
    public TextMeshProUGUI TurnText;
    public Button TurnButton;

    public bool IsPlayerTurn
    {
        get
        {
            return turn % 2 ==  0;
        }
    }

    public void Start()
    {
        turn = 0;

        game = new Game();

        GiveHandCard(game.EnemyDeck, EnemyHand);
        GiveHandCard(game.PlayerDeck, PlayerHand);

        StartCoroutine(TurnFunc());
    }

    public void GiveHandCard(List<Card> deck, Transform parent)
    {
        for (int i = 0; i < 6; i++)
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

    IEnumerator TurnFunc()
    {
        turnTime = 30;
        TurnText.text  =  turnTime.ToString();

        if (IsPlayerTurn)
        {
            while (turnTime-- > 0)
            {
                TurnText.text  = turnTime.ToString();
                yield return  new WaitForSeconds(1);
            }
        }
        else
        {
            while (turnTime-- > 27)
            {
                TurnText.text  = turnTime.ToString();
                yield return  new WaitForSeconds(1);
            }
        
        }
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        StopAllCoroutines();
        turn++;
        TurnButton.interactable = IsPlayerTurn;
        if (IsPlayerTurn)
            GiveNewCards();
        StartCoroutine(TurnFunc());
    }

    public void GiveNewCards()
    {
        GiveCardToHand(game.EnemyDeck, EnemyHand);
        GiveCardToHand(game.PlayerDeck, PlayerHand);
    }
}
