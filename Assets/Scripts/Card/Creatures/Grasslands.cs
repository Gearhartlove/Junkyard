using UnityEditor;
using UnityEngine;

public class Grasslands : MonoBehaviour, ICard
{
    private string title = "Grasslands";

    public CardDatabase.CardType GetCardType() {
        return CardDatabase.CardType.Creature;
    }

    public string GetTitle() {
        return title;
    }

    public Sprite GetArtAsset() {
        Sprite mySprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Grasslands.png", typeof(Sprite));
        return mySprite;
    }
}
