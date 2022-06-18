using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardTemplate : MonoBehaviour {
    private SpriteRenderer art;
    private SpriteRenderer background;
    private TextMeshProUGUI body;
    private Collider2D collider;
    private Rigidbody2D rigidbody2D;
    private TextMeshProUGUI text;

    // TODO: spawn card prefab, change out data
    
    // Start is called before the first frame update
    void Start() {
         art = gameObject.transform.Find("Art")
            .GetComponent<SpriteRenderer>();
         background = gameObject.transform.Find("Background")
             .GetComponent<SpriteRenderer>();
         body = gameObject.transform.Find("Canvas").Find("Body")
             .GetComponent<TextMeshProUGUI>();
         text = gameObject.transform.Find("Canvas").Find("Title")
             .GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
