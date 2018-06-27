using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.U2D;

public class Main : MonoBehaviour {

    static GameObject root;
    public static SpriteAtlas atlas;

    GameObject square;
    Ground g;
    Obstacle o;
    GenericAgent ga;
    SmoothLightingManager slm;

	// Use this for initialization
	void Start () {

        root = gameObject;

        atlas = Resources.Load<SpriteAtlas>("sprites/atlas");

        var cam = Camera.main;

        cam.gameObject.AddComponent<CameraController>();

        square = GameObject.CreatePrimitive(PrimitiveType.Quad);
        square.transform.position = new Vector3(0, 0, 0);

        g = Ground.Create();
        ga = GenericAgent.Create(new Vector3(5, 1, 5));

        o = Obstacle.Create(new Vector3(3, 0, 3));
        Obstacle.Create(new Vector3(1, 0, 1));

        slm = SmoothLightingManager.Create();
        
    }

    // Update is called once per frame
    void Update () {

        var deltaX = (float) (Math.Cos(Time.time) * 0.5);

        square.transform.Translate(deltaX, 0, 0);
	}
}
