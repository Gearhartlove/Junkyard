using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;


public class Hand : MonoBehaviour
{
    public GameObject this[int index] => hand[index];

    [SerializeField] private List<GameObject> hand;
    public List<GameObject> Cards() => hand;
    private int maxHandSize = 7;
    public int MaxHandSize => maxHandSize;
    private static readonly (double, double) CardSpawn = (0.0, -5.35);

    // Start is called before the first frame update
    void Start() {
        hand = new List<GameObject>();
    }

    public void AddCardToHand(GameObject card) {
        hand.Add(card);
    }

    public GameObject PlayCardFromHand(GameObject card) {
        hand.Remove(card);
        return card;
    }

    // public void DrawFullHand(Deck deck) {
    //     int cardsToDraw = maxHandSize - CardCount();
    //     for (; cardsToDraw != 0; cardsToDraw--) {
    //         // GameObject topCard = deck.Draw();
    //         // AddCardToHand(topCard);
    //     } 
    // }

    public bool IsFull() => CardCount == maxHandSize;

    public int CardCount => hand.Count; 
    
    /// <summary>
    /// Repositions the players cards whenever a card is queried, removed, or drawn, or ... 
    /// </summary>
    public void UpdateCardScreenPositions() {
       // TODO 
    }
}
