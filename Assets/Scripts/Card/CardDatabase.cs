using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {
    private static readonly Dictionary<Enum, Action<GameObject>> CreatureHash;
    private static readonly Dictionary<Enum, Action<GameObject>> ScrapHash;

    public static readonly Dictionary<CardType, Dictionary<Enum, Action<GameObject>>>  CardHash;

    static CardDatabase() {
        CreatureHash = new Dictionary<Enum, Action<GameObject>>() {
            { CreatureCard.Goblin, (card) => card.AddComponent<Goblin>()},
            { CreatureCard.Template, (card) => card.AddComponent<CreatureTemplate>()},
            { CreatureCard.Grasslands, (card) => card.AddComponent<Grasslands>()},
            { CreatureCard.Troll, (card) => card.AddComponent<Troll>()},
        };

        ScrapHash = new Dictionary<Enum, Action<GameObject>>() {};

        CardHash = new Dictionary<CardType, Dictionary<Enum, Action<GameObject>>>() {
            // creature dic
            { CardType.Creature, CreatureHash },
            { CardType.Scrap, ScrapHash },
        };
    }
    
    private static CardDatabase instance;
    
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

    public enum CreatureCard {
        Template,
        Goblin,
        Grasslands,
        Troll,
    }

    public enum ScrapCard {}
}


