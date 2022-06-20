using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour {
    private Stack<GameObject> deck;
    public  Stack<GameObject> GetDeck => deck;

    private int cardsInDeck = 0;
    public int GetCardsInDeck => cardsInDeck;

    private void Awake() {
        deck = new Stack<GameObject>();
    }

    public GameObject Top() {
        return deck.Peek();
    }

    public GameObject Bottom() {
        return deck.Last();
    }

    public void Push(GameObject card) {
        cardsInDeck++;
        deck.Push(card);
    }

    public GameObject Pop() {
        cardsInDeck--;
        return deck.Pop();
    }

    public bool IsEmpty() {
        return cardsInDeck == 0;
    }
}
