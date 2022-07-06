using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CardDatabase;

public class Deck : MonoBehaviour {
    private Stack<GameObject> deck;

    public int CardCount => deck.Count;

    private void Awake() {
        // todo: Create deck interface, for Yard and Deck and future deck-like collections (exile?) to differentiate themselves
        bool notTheYard = !gameObject.name.ToLower().Equals("yard");

        if (notTheYard) {
            deck = new Stack<GameObject>();
            AddCard(CardType.Creature, CreatureCard.Goblin);
            AddCard(CardType.Creature, CreatureCard.Grasslands);
            AddCard(CardType.Creature, CreatureCard.Troll);
            AddCard(CardType.Template, TemplateCard.Template);
        }
    }

    /// <summary>
    /// Adds a single card to a deck and returns the deck. Used as a builder pattern in the Deck.cs Awake method.
    /// </summary>
    /// <param name="cardName"></param>
    /// <returns></returns>
    private void AddCard(CardType cardType, Enum cardName) {
        var card = Card.Create(cardType, cardName);
        // set the parent of the card to the Deck GameObject
        card.transform.parent = gameObject.transform;
        PositionCard(card);
        deck.Push(card);
    }

    public GameObject Top() {
        return deck.Peek();
    }

    public GameObject Bottom() {
        return deck.Last();
    }

    public void Push(GameObject card) {
        deck.Push(card);
    }

    public GameObject Pop() {
        return deck.Pop();
    }

    public bool IsEmpty() {
        return deck.Count == 0;
    }

    public GameObject[] AsArray() {
        return deck.ToArray();
    }

    public void AssignDeck(GameObject[] deckArray) {
        deck = new Stack<GameObject>(deckArray);
    }

    // public Stack<GameObject> CreateDeck(List<CardName> cards) {
    //     Stack<GameObject> deck = new Stack<GameObject>();
    //     foreach (CardName cardName in cards) {
    //         var card = Card.Create(cardName);
    //         // set the parent of teh card to the Deck GameObject
    //         card.transform.parent = gameObject.transform;
    //         PositionCard(card);
    //         deck.Push(card);
    //     }
    //
    //     return deck;
    // }

    private const float START_X = 6.57f;
    private const float START_Y = 0f;
    private float START_Z = 10f; // todo: understand Z position better, sorting layers?
    /// <summary>
    /// Whenever a card is added to your hand, insert it to the right of the most recently
    /// added card;
    /// </summary>
    /// <param name="card"></param>
    private void PositionCard(GameObject card) {
        card.transform.position = new Vector3(START_X, START_Y, START_Z);
        START_Z -= 0.1f;
    }
}