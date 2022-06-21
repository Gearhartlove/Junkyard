using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Hand hand;
    public Hand Hand => hand;
    
    private Deck deck;
    public Deck Deck => deck;
    private Deck yard;
    public Deck Yard => yard;
    
    // Start is called before the first frame update
    void Start() {
        hand = gameObject.AddComponent<Hand>();
        deck = gameObject.AddComponent<Deck>();
        yard = gameObject.AddComponent<Deck>();
    }
    
    // Player Actions ----------------------------------------------------------------------
    
    /// <summary>
    /// Move X cards from the top of the player's deck to the yard.
    /// </summary>
    /// <param name="toMill"></param>
    public void Mill(int toMill = 1) {
        for (; toMill > 0 && deck.CardCount != 0; toMill--) {
            var popCard = deck.Pop();
            yard.Push(popCard);
        }
    }

    /// <summary>
    /// Adds a card Game Object to the top of the deck.
    /// </summary>
    /// <param name="card"></param>
    public void AddCardToDeck(GameObject card) {
        deck.Push(card);
    }
    
    /// <summary>
    /// Pops the top card of the deck and returns that card.
    /// </summary>
    /// <returns></returns>
    public void Draw(int toDraw = 1) {
        for (; toDraw > 0 && deck.CardCount != 0; toDraw--) {
            if (hand.IsFull()) {
                Mill();
            }
            else {
                var drawnCard = deck.Pop();
                hand.AddCardToHand(drawnCard);                
            }
        }
    }

    // public void Scry(int x = 1) {
    //     for (; x > 0 && deck.CardCount != 0; x--) {
    //         var scryCard = deck.Pop();
    //     }
    // }

    /// <summary>
    /// Shuffle the deck of cards using the Fisher-Yates Shuffle.
    /// For the first iteration, the algorithm looks at the first card in the deck, and then switches
    /// it with another card in the deck. For the second iteration, the second card in
    /// the deck is switched with another card in the deck, excluding the already swapped
    /// first card. Every index is swapped, excluding the last card in the deck.
    /// source: https://www.quora.com/Are-there-any-better-shuffling-algorithms-than-Fisher–Yates-shuffle
    /// --> Eugene Yarovoi with great explanation 
    /// </summary>
    public void Shuffle() {
        var deckArray = deck.AsArray(); 
        for (int i = 0; i < deck.CardCount; i++) {
            int pos = i + (Random.Range(0, Deck.CardCount - i));
            // swap
            GameObject temp = deckArray[pos];
            deckArray[pos] = deckArray[i];
            deckArray[i] = temp;
        }
        deck.AssignDeck(deckArray);
    }

    public void Discard(int cardIndex) {
        var card = Hand[cardIndex];
        hand.Cards().Remove(card);
        yard.Push(card);
    }
}
