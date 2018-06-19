using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Main : MonoBehaviour {

    GameObject square;

	// Use this for initialization
	void Start () {
        var cam = Camera.main;

        cam.gameObject.AddComponent<CameraController>();

        square = GameObject.CreatePrimitive(PrimitiveType.Quad);
        square.transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        var deltaX = (float) (Math.Cos(Time.time) * 0.5);

        square.transform.Translate(deltaX, 0, 0);
	}
}
