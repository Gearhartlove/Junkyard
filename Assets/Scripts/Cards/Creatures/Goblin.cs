using System;
using UnityEngine;

public class Goblin : MonoBehaviour, ICard, ICreature {
    private String name = "Goblin";
    private float power = 1;
    private float toughness = 1;

    public string GetName() {
        return name;
    }

    public float GetPower() {
        return power;
    }

    public float GetToughness() {
        return toughness;
    }
    
    public void Attack() {
        throw new System.NotImplementedException();
    }

    public void Target() {
        throw new System.NotImplementedException();
    }

    public void ActivateAbility() {
        throw new System.NotImplementedException();
    }
}
