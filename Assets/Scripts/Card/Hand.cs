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
    private int MaxHandSize = 7;
    private int CurrentHandSize = 0;

    private static readonly (double, double) CardSpawn = (0.0, -5.35);

    // Start is called before the first frame update
    void Start() {
        hand = new List<GameObject>();
    }

    List<GameObject> GetCardsInHand() => hand;

    public void AddCardToHand(GameObject card) {
        if (card.GetComponent<ICard>() == null) {
            throw new Exception("Cannot add card to hand");
        }
        else if (CurrentHandSize >= MaxHandSize) {
            // todo: define max hand size behavior
        }
        else {
            hand.Add(card);   
        }
    }

    public GameObject PlayCardFromHand(GameObject card) {
        if (card.GetComponent<ICard>() == null) {
            throw new Exception("Cannot add card to hand");
        }
        hand.Remove(card);
        return card;
    }

    public void DrawFullHand(Deck deck) {
        int cardsToDraw = MaxHandSize - CurrentHandSize;
        for (; cardsToDraw != 0; cardsToDraw--) {
            // GameObject topCard = deck.Draw();
            // AddCardToHand(topCard);
        } 
    }

    public bool IsFull() => CurrentHandSize >= MaxHandSize;
    
    /// <summary>
    /// Repositions the players cards whenever a card is queried, removed, or drawn, or ... 
    /// </summary>
    public void UpdateCardScreenPositions() {
       // TODO 
    }
}
