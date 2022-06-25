using TMPro;
using UnityEngine;

public class Components : MonoBehaviour {
    private SpriteRenderer art;
    private SpriteRenderer background;
    private Collider2D collider;
    private Rigidbody2D rigidbody;
    private TextMeshProUGUI title;
    private TextMeshProUGUI body;

    // updated at runtime, all information below relies in this data
    private ICard cardData; 

    // Start is called before the first frame update
    void Awake() {
         art = gameObject.transform.Find("Art")
            .GetComponent<SpriteRenderer>();
         background = gameObject.transform.Find("Background")
             .GetComponent<SpriteRenderer>();
         collider = transform.GetComponent<Collider2D>();
         rigidbody = transform.GetComponent<Rigidbody2D>();
         body = gameObject.transform.Find("Canvas").Find("Body")
             .GetComponent<TextMeshProUGUI>();
         title = gameObject.transform.Find("Canvas").Find("Title")
             .GetComponent<TextMeshProUGUI>();
    }

    // Get Components
    public SpriteRenderer GetArt() => art;
    public SpriteRenderer GetBackground() => background;
    public Collider2D GetCollider() => collider;
    public Rigidbody2D GetRigidBody() => rigidbody;
    public TextMeshProUGUI GetTitle() => title;
    public TextMeshProUGUI GetBody() => body;
    
    public void Update() {
        ICard data = gameObject.GetComponent<ICard>();
        art.sprite = data.GetArtAsset();
        title.text = data.GetTitle().ToUpper();
    }
}


