using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour {

    public static Obstacle Create(Vector3 loc) {
        var go = new GameObject("Obstacle");
        go.transform.position = loc;

        return go.AddComponent<Obstacle>();
    }

    NavMeshObstacle nmo;

	// Use this for initialization
	void Start () {
        nmo = gameObject.AddComponent<NavMeshObstacle>();
        nmo.carving = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
