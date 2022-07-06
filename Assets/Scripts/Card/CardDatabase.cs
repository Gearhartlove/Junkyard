using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {
    private static readonly Dictionary<Enum, Action<GameObject>> CreatureHash;
    private static readonly Dictionary<Enum, Action<GameObject>> ScrapHash;
    private static readonly Dictionary<Enum, Action<GameObject>> TemplateHash;

    public static readonly Dictionary<CardType, Dictionary<Enum, Action<GameObject>>>  CardHash;

    static CardDatabase() {
        CreatureHash = new Dictionary<Enum, Action<GameObject>>() {
            { CreatureCard.Goblin, (card) => card.AddComponent<Goblin>()},
            { CreatureCard.Grasslands, (card) => card.AddComponent<Grasslands>()},
            { CreatureCard.Troll, (card) => card.AddComponent<Troll>()},
        };

        ScrapHash = new Dictionary<Enum, Action<GameObject>>() {};

        TemplateHash = new Dictionary<Enum, Action<GameObject>>() {
            { TemplateCard.Template, (card) => card.AddComponent<CreatureTemplate>()},

        };
        
        CardHash = new Dictionary<CardType, Dictionary<Enum, Action<GameObject>>>() {
            // creature dic
            { CardType.Creature, CreatureHash },
            { CardType.Scrap, ScrapHash },
            { CardType.Template, TemplateHash }
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
        Template,
    }

    public enum CreatureCard {
        Goblin,
        Grasslands,
        Troll,
    }

    public enum ScrapCard {}

    public enum TemplateCard {
        Template,
    }
}


