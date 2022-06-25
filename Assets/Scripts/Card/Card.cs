using UnityEditor;
using UnityEngine;
using static CardDatabase;

public class Card : MonoBehaviour {
    private Components components;
    private CardName prevCardName;
    
    [SerializeField]
    private CardName currentCardName;

    // Start is called before the first frame update
    void Start() {
        // render card
        currentCardName = CardName.Template;
        prevCardName = currentCardName;

        // add components to card
        CardHash[currentCardName](gameObject);

        // get components
        components = transform.GetComponent<Components>();
        components.Update();
    }

    // Update is called once per frame
    void Update() {
        if (currentCardName != prevCardName) {
            // remove card data
            Destroy(GetComponent(prevCardName.ToString()));
            // add card data
            CardHash[currentCardName](gameObject);
            prevCardName = currentCardName;
            components.Update();
        }
    }
    
    /// <summary>
    /// Create a card of a desired name
    /// </summary>
    /// <param name="cardName"></param>
    /// <returns></returns>
    public static GameObject Create(CardName cardName) {
        // create copy of template card
        var templateCard = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/TemplateCard.prefab", typeof(GameObject));
        var createdCard = Instantiate(templateCard);
        
        // change template card to desired card
        createdCard.name = cardName.ToString();
        CardHash[cardName](createdCard);
        return createdCard;
    }
}