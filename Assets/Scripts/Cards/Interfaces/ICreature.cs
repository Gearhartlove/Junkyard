using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature {
    // Stats
    float GetPower();
    float GetToughness();

    // Actions
    void Attack();
    void Target();
    void ActivateAbility();
}