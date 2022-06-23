using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature { 
    // Actions
    void Attack();
    void Target();
    void ActivateAbility();
}