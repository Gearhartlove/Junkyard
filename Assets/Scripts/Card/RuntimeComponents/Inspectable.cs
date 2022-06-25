using UnityEngine;

public class Inspectable : MonoBehaviour {
    private static readonly Vector3 MOVE_UP = new Vector3(0, 1.46f, 0);
    private bool hover = false;
    private Camera cam;
    private Vector3 originalPos;
    private Vector3 newPos;
    
    private void Awake() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (hover) {
            if (originalPos == Vector3.zero || originalPos.x != transform.position.x) {
                originalPos = transform.position;
                newPos = originalPos + MOVE_UP;
            }
            // enlarge
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
            transform.position = newPos;
        }
        
    }

    public void OnMouseOver() {
        hover = true;
    }

    public void OnMouseExit() {
        Reset();
    }

    public void Reset() {
        hover = false;
        // shrink
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = originalPos;
    }
}
