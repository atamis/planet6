using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour {

    GameObject model;

    public static Obstacle Create(Vector3 loc) {
        var go = new GameObject("Obstacle");
        go.transform.position = loc;

        var obs = go.AddComponent<Obstacle>();

        obs.model = new GameObject("Model");
        obs.model.transform.parent = go.transform;
        obs.model.transform.localPosition = Layers.ModelEnvironment;

        var sr = obs.model.AddComponent<SpriteRenderer>();
        sr.sprite = Main.atlas.GetSprite("temp-rock");
        obs.model.AddComponent<Billboard>();


        return obs;
    }

    NavMeshObstacle nmo;

	// Use this for initialization
	void Start () {
        nmo = gameObject.AddComponent<NavMeshObstacle>();
        nmo.carving = true;
        nmo.size = new Vector3(0.5f, 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
