using UnityEngine;

public class Draggable : MonoBehaviour {
    private bool hover = false;
    private bool mouseDown = false;
    private Vector3 mouseWorldPos;
    private Vector3 offset;
    private Camera cam;

    private float speed = 15f;

    private void Awake() {
        cam = Camera.main;
    }

    void Dragging() {
        mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        offset = transform.position - mouseWorldPos;
        //drag
        // todo: POLISH Smooth out
        transform.position = Vector3.Lerp(transform.position, mouseWorldPos, speed * Time.deltaTime);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            mouseDown = false;
        }
        if (mouseDown && hover) {
            Dragging();
        }
    }

    public void OnMouseOver() {
        hover = true;
    }

    private void OnMouseExit() {
        if (!mouseDown) { 
            hover = false;
        }
    }
}