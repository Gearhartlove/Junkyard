using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour {
    private Stack<GameObject> deck;

    public int CardCount => deck.Count;

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
}