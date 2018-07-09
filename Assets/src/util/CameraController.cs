
using UnityEngine;

public class CameraController : MonoBehaviour {
    Camera cam;
    private int defaultMask;
    void Start() {
        cam = Camera.main;
        cam.orthographic = false;

        defaultMask = cam.cullingMask ^ 1 << 8; // remove CustomLight

        cam.cullingMask = defaultMask; // Remove CustomLight

        gameObject.transform.position = new Vector3(0, 10, 0);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
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

        // TODO: if orthographic, SLC zoom has to be adjusted too.
        // Normalize so diagonal movement isn't bizarrely fast
        gameObject.transform.Translate(trans.normalized * 0.2f);
       

        if (Input.GetKey(KeyCode.Q)) {
            // TODO: debounce
            cam.cullingMask ^= 1 << 9; // Toggle power
        }
    }
}