using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLightCamera : MonoBehaviour {
    
    public static SmoothLightCamera Create(RenderTexture rt) {
        var mask = 1 << 8; // CustomLight

        var go = new GameObject("Smooth Light Camera");
        go.transform.parent = Camera.main.transform;
        Camera.main.cullingMask = Camera.main.cullingMask - mask;
        go.transform.localPosition = new Vector3(0, 0, 0);
        go.transform.localEulerAngles = new Vector3(0, 0, 0);


        var cam = go.AddComponent<Camera>();
        cam.cullingMask = mask;
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = Color.black;
        cam.targetTexture = rt;
            
        var slc = go.AddComponent<SmoothLightCamera>();
        
        return slc;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // TODO: do this less for performance reasons?
        transform.parent = Camera.main.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
