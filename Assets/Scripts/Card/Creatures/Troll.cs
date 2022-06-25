using UnityEditor;
using UnityEngine;

public class Troll : MonoBehaviour, ICard, ICreature {
    private string title = "Troll";
    private float flux = 4;

    public string GetTitle() {
        return title;
    }

    public Sprite GetArtAsset() {
        Sprite mySprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Troll.png", typeof(Sprite));
        return mySprite;
    }

    public float GetPower() {
        throw new System.NotImplementedException();
    }

    public float GetToughness() {
        throw new System.NotImplementedException();
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
