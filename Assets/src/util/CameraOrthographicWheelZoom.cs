using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrthographicWheelZoom : MonoBehaviour {

    private Camera cam;

    void OnEnable() {
        this.cam = GetComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = 5;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cam.orthographicSize += -Input.GetAxis("Mouse ScrollWheel");

        cam.orthographicSize = Math.Max(cam.orthographicSize, 0.01f);
    }
}
