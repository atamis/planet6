using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.U2D;

public class Main : MonoBehaviour {

    public static GameObject root;
    public static SpriteAtlas atlas;

    GameObject square;
    GameObject indicator;
    Ground g;
    GameObject o;
    GenericAgent ga;
    SmoothLightingManager slm;

	// Use this for initialization
	void Start () {

        // 8 is CustomLight, because CustomLight collision is used to probe lighting.
        Physics.IgnoreLayerCollision(0, 8);
        // 9 is Power.
        Physics.IgnoreLayerCollision(0, 9);
        Camera.main.cullingMask = Camera.main.cullingMask - (1 << 7);

        root = gameObject;

        atlas = Resources.Load<SpriteAtlas>("sprites/atlas");

        var instance = BuildingManager.instance;

        var cam = Camera.main;

        cam.gameObject.AddComponent<CameraController>();

        square = GameObject.CreatePrimitive(PrimitiveType.Quad);
        square.transform.position = new Vector3(0, 0, 0);

        g = Ground.Create();
        //ga = GenericAgent.Create(new Vector3(5, 1, 5));

        o = Obstacle.Create(new Vector3(3, 0, 3));
        o.AddComponent<SmoothLightProbe>();
        Obstacle.Create(new Vector3(2, 0, 2));

        //slm = SmoothLightingManager.Create();

        var baseGo = new GameObject("Base");
        baseGo.transform.position = new Vector3(0, Layers.Environment, 0);
        BuildingManager.instance.baseBuilding = baseGo.AddComponent<BaseBuilding>();

        var relayGo = new GameObject("Relay");
        relayGo.transform.position = new Vector3(-3, Layers.Environment, 0);
        relayGo.AddComponent<RelayBuilding>();

        VisualLightIndicator.Create(new Vector3(7, 0.2f, 7));
        var lightGo = new GameObject("Light");
        lightGo.transform.position = new Vector3(7, Layers.Environment, -7);
        lightGo.AddComponent<LightBuilding>();

        var turretGo = new GameObject("Turret");
        turretGo.transform.position = new Vector3(3, Layers.Environment, 0);
        turretGo.AddComponent<LaserTurretBuilding>();

        indicator = new GameObject("Indicator");
        indicator.transform.position = new Vector3(0, Layers.Environment, 0);
        SimpleQuad.ImmediateAdd(indicator, 1, 1);
        indicator.AddComponent<RoundLocation>();
        indicator.GetComponent<MeshRenderer>().material.mainTexture = Texture2D.blackTexture;
    }

    // Update is called once per frame
    void Update () {

        var deltaX = (float) (Math.Cos(Time.time) * 0.5);

        square.transform.Translate(deltaX, 0, 0);


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        if (Input.GetKey(KeyCode.E) && Physics.Raycast(ray.origin, ray.direction, out hitinfo)) {
            indicator.transform.position = new Vector3(hitinfo.point.x, Layers.Environment, hitinfo.point.z);
        }


        if (Input.GetMouseButtonDown(1) && !Input.GetKey(KeyCode.LeftShift)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitinfo)) {
                var relayGo = new GameObject("Relay");
                relayGo.transform.position = new Vector3(hitinfo.point.x, Layers.Environment, hitinfo.point.z);
                relayGo.AddComponent<RelayBuilding>();
            }

        }


        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitinfo)) {
                var go = new GameObject("Some Enemy");
                go.transform.position = hitinfo.point;
                go.AddComponent<EnemyUnit>();
            }

        }



    }
}
