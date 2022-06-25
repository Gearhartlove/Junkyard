using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {
    private static CardDatabase instance;
    public static readonly Dictionary<CardName, Action<GameObject>> CardHash;

    static CardDatabase() {
        //initialize hash table 
        CardHash = new Dictionary<CardName, Action<GameObject>>() {
            {CardName.Template, (card) => card.AddComponent<CreatureTemplate>()},
            {CardName.Goblin, (card) => card.AddComponent<Goblin>()},
            {CardName.Grasslands, (card) => card.AddComponent<Grasslands>()},
            {CardName.Troll, (card) => card.AddComponent<Troll>()},
        };
    }
    
    public static CardDatabase Instance {
        get { return instance; }
    }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }

    }

    public enum CardType {
        Creature,
        Scrap,
    }
    
    public enum CardName {
        Template,
        Goblin,
        Grasslands,
        Troll,
    }
}


