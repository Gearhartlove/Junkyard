using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {
    private Vector3 position;
    public Vector3 GetAnchor => position;

    private void Start() {
        position = transform.position;
    }

    public void UpdateAnchor() {
        position = transform.position;
    }
}
