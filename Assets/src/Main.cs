using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Main : MonoBehaviour {

    static GameObject root;

    GameObject square;
    Ground g;
    Obstacle o;
    GenericAgent ga;

	// Use this for initialization
	void Start () {

        root = gameObject;

        var cam = Camera.main;

        cam.gameObject.AddComponent<CameraController>();

        square = GameObject.CreatePrimitive(PrimitiveType.Quad);
        square.transform.position = new Vector3(0, 0, 0);

        g = Ground.Create();
        o = Obstacle.Create(new Vector3(3, 0, 3));
        ga = GenericAgent.Create(new Vector3(5, 1, 5));

    }
	
	// Update is called once per frame
	void Update () {

        var deltaX = (float) (Math.Cos(Time.time) * 0.5);

        square.transform.Translate(deltaX, 0, 0);
	}
}
