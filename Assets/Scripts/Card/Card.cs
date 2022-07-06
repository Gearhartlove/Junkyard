using System;
using UnityEditor;
using UnityEngine;
using static CardDatabase;

public class Card : MonoBehaviour {
    private Components components;
    private CardType prevCardType;
    private Enum prevCardName;

    [SerializeField] private CardType currentCardType;
    [SerializeField] private Enum currentCardName;

    // Start is called before the first frame update
    void Start() {
        // render card
        currentCardName = TemplateCard.Template;
        prevCardName = currentCardName;
        currentCardType = CardType.Creature;
        prevCardType = currentCardType;

        AddComponentsToCard(currentCardType, currentCardName, gameObject);
        
        // get components
        components = transform.GetComponent<Components>();
        components.Update();
    }

    // Update is called once per frame
    void Update() {
        if (currentCardName != prevCardName) {
            // remove card data
            Destroy(GetComponent(prevCardName.ToString()));
            AddComponentsToCard(currentCardType, currentCardName, gameObject);
            prevCardName = currentCardName;
            components.Update();
        }
    }
    
    /// <summary>
    /// Create a card of a desired name
    /// </summary>
    /// <param name="cardName"></param>
    /// <returns></returns>
    public static GameObject Create(CardType cardType, Enum cardName) {
        // create copy of template card
        var templateCard = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/TemplateCard.prefab", typeof(GameObject));
        var createdCard = Instantiate(templateCard);
        
        // change template card to desired card
        createdCard.name = cardName.ToString();
        AddComponentsToCard(cardType, cardName, createdCard);
        return createdCard;
    }

    private static void AddComponentsToCard(CardType cardType, Enum cardName, GameObject go) {
        CardHash[cardType][cardName](go);
    }
}