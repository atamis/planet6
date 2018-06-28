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
    GameObject o;
    GenericAgent ga;
    SmoothLightingManager slm;

	// Use this for initialization
	void Start () {

        // 8 is CustomLight, because CustomLight collision is used to probe lighting.
        Physics.IgnoreLayerCollision(0, 8);

        root = gameObject;

        atlas = Resources.Load<SpriteAtlas>("sprites/atlas");

        var cam = Camera.main;

        cam.gameObject.AddComponent<CameraController>();

        square = GameObject.CreatePrimitive(PrimitiveType.Quad);
        square.transform.position = new Vector3(0, 0, 0);

        g = Ground.Create();
        ga = GenericAgent.Create(new Vector3(5, 1, 5));

        o = Obstacle.Create(new Vector3(3, 0, 3));
        o.AddComponent<SmoothLightProbe>();
        Obstacle.Create(new Vector3(1, 0, 1));

        slm = SmoothLightingManager.Create();


        VisualLightIndicator.Create(new Vector3(7, 0.2f, 7));
    }

    // Update is called once per frame
    void Update () {

        var deltaX = (float) (Math.Cos(Time.time) * 0.5);

        square.transform.Translate(deltaX, 0, 0);
	}
}
