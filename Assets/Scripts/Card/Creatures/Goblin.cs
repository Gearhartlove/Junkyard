using UnityEditor;
using UnityEngine;

public class Goblin : MonoBehaviour, ICard, ICreature {
    private string title = "Goblin";
    private float flux = 1;

    public CardDatabase.CardType GetCardType() {
        return CardDatabase.CardType.Creature;
    }

    public string GetTitle() {
        return title;
    }

    public Sprite GetArtAsset() {
        Sprite mySprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Goblin.png", typeof(Sprite));
        return mySprite;
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
