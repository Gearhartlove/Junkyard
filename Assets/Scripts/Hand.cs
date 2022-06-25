using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public GameObject this[int index] => hand[index];

    [SerializeField] private List<GameObject> hand;
    public List<GameObject> Cards() => hand;

    private int maxHandSize = 7;
    public int MaxHandSize => maxHandSize;

    private List<GameObject> holding;

    // Start is called before the first frame update
    void Start() {
        hand = new List<GameObject>();
    }

    // Called from Holdable Script OnMouseDown()
    public static void HoldCard(GameObject card) {
        RemoveInspectable(card);
        MakeDraggable(card);
        // holding.Add(card);
    }
    // Called from Holdable Script OnMouseUp()
    // todo: fix Inspectable enlarging card one frame after release. 
    public static void StopHoldingCard(GameObject card) {
        RemoveDraggable(card);
        RestorePosition(card);
        MakeInspectable(card);
    }
    
    public void AddCardToHand(GameObject card) {
        TakeOwnership(card);
        MakeInspectable(card);
        MakeHoldable(card);
        AddAnchor(card);
        hand.Add(card);
        PositionCards();
    }

    // public GameObject PlayCardFromHand(GameObject card) {
    //     RemoveInspectable(card);
    //     RemoveDraggable(card);
    //     hand.Remove(card);
    //     PositionCards();
    //     return card;
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
        float
            startPos = CARD_SPACING * (CardCount - 1) *
                       -1; // multiply by negative one because hand starts on the left and goes right
        for (int i = 0; i < CardCount; i++) {
            float newXPos = startPos + (CARD_SPACING * i * 2);
            var card = Cards()[i];
            card.transform.position = new Vector3(newXPos, CARD_HEIGHT, 0);
            UpdateAnchor(card);
        }
    }

    private void UpdateAnchor(GameObject card) {
        var anchor = card.GetComponent<Anchor>();
        anchor.UpdateAnchor();
    }

    private void TakeOwnership(GameObject card) {
        card.transform.parent = gameObject.transform;
    }

    private static void MakeInspectable(GameObject card) {
        card.AddComponent<Inspectable>();
    }

    private static void RemoveInspectable(GameObject card) {
        var inspectable = card.GetComponent<Inspectable>();
        inspectable.Reset();
        Destroy(card.GetComponent<Inspectable>());
    }

    private static void MakeDraggable(GameObject card) {
        card.AddComponent<Draggable>();
    }

    private static void RemoveDraggable(GameObject card) {
        Destroy(card.GetComponent<Draggable>());
    }

    private static void MakeHoldable(GameObject card) {
        card.AddComponent<Holdable>();
    }

    private static void RemoveHoldable(GameObject card) {
        Destroy(card.AddComponent<Holdable>());
    }
    
    private static void AddAnchor(GameObject card) {
        card.AddComponent<Anchor>();
    }
    
    private static void RestorePosition(GameObject card) {
        var anchor = card.GetComponent<Anchor>();
        card.transform.position = anchor.GetAnchor;
    }
}
