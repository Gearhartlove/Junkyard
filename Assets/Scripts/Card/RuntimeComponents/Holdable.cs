using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Holdable : MonoBehaviour {
    private void OnMouseDown() {
        Hand.HoldCard(gameObject);
    }
    
    private void OnMouseUp() {
        Hand.StopHoldingCard(gameObject);
    }
}
