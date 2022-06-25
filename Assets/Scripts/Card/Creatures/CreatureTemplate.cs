using UnityEditor;
using UnityEngine;

public class CreatureTemplate : MonoBehaviour, ICard, ICreature {
    private string title = "Template";
    private float flux = 0;

    public string GetTitle() {
        return title;
    }

    public Sprite GetArtAsset() {
        Sprite mySprite = (Sprite) AssetDatabase.LoadAssetAtPath("Assets/Sprites/Template.png", typeof(Sprite));
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
