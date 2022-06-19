using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {
    private static CardDatabase instance;
    public static readonly Dictionary<CardName, Action<GameObject>> CardHash;

    static CardDatabase() {
        //initialize hash table 
        CardHash = new Dictionary<CardName, Action<GameObject>>() {
            {CardName.Goblin, (card) => card.AddComponent<Goblin>()}
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
        Template,
    }
    
    public enum CardName {
        Template,
        Goblin,
        ScrapBomb,
    }
}


