
using UnityEngine;

public class CameraController : MonoBehaviour {
    Camera cam;
    void Start() {
        cam = Camera.main;
        cam.orthographic = false;
    }
    
    void Update() {
        var trans = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.A)) {
            trans = trans + new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D)) {
            trans = trans + new Vector3(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.W)) {
            trans = trans + new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.S)) {
            trans = trans + new Vector3(0, -1, 0);
        }

        trans = trans + new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));

        // Normalize so diagonal movement isn't bizarrely fast
        gameObject.transform.Translate(trans.normalized * 0.2f);
    }
}