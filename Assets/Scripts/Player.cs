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
        
        hand.DrawFullHand(deck);
    }
    
    // Player Actions
    
    /// <summary>
    /// Move X cards from the top of the player's deck to the yard.
    /// </summary>
    /// <param name="toMill"></param>
    public void Mill(int toMill = 1) {
        for (; toMill > 0 && deck.GetDeck.Count != 0; toMill--) {
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
        for (; toDraw > 0 && deck.GetDeck.Count != 0 && !hand.IsFull(); toDraw--) {
            var drawnCard = deck.Pop();
            hand.AddCardToHand(drawnCard);
        }
    }

}
