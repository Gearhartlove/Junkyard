using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Card : MonoBehaviour {
    private Components components;
    private CardDatabase.CardName prevCard;


    [FormerlySerializedAs("card")] [SerializeField]
    private CardDatabase.CardName currentCard;

    // Start is called before the first frame update
    void Start() {
        
        // render card
        currentCard = CardDatabase.CardName.Goblin;
        prevCard = currentCard;

        // add components to card
        CardDatabase.CardHash[currentCard](gameObject);

        // get components
        components = transform.GetComponent<Components>();
        components.Update();
        // render card
        //this.Render();
    }

    // Update is called once per frame
    void Update() {
        if (currentCard != prevCard) {
            // remove card data
            Destroy(GetComponent(prevCard.ToString()));
            // add card data
            CardDatabase.CardHash[currentCard](gameObject);
            prevCard = currentCard;
            components.Update();
        }
    }
}