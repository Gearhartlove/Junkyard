using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        TakeOwnership(card);
        hand.Add(card);
        PositionCards();
    }

    private void TakeOwnership(GameObject card) {
        card.transform.parent = gameObject.transform;
    }

    public GameObject PlayCardFromHand(GameObject card) {
        hand.Remove(card);
        PositionCards();
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

    private const float CARD_SPACING = 1.0f;
    private const float CARD_HEIGHT = -4.1f;
    /// <summary>
    /// Whenever a card is added to your hand, insert it to the right of the most recently
    /// added card;
    /// </summary>
    /// <param name="card"></param>
    private void PositionCards() {
        float startPos = CARD_SPACING * (CardCount-1) * -1; // multiply by negative one because hand starts on the left and goes right
        for (int i = 0; i < CardCount; i++) {
            float newXPos = startPos + (CARD_SPACING * i * 2);
            Cards()[i].transform.position = new Vector3(newXPos, CARD_HEIGHT, 0);
        }
    }
}
