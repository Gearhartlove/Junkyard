using UnityEngine;

public class Holdable : MonoBehaviour {
    private void OnMouseDown() {
        Hand.HoldCard(gameObject);
    }
    
    private void OnMouseUp() {
        Hand.StopHoldingCard(gameObject);
    }
}
