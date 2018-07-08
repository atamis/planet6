using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WorldObject))]
public class Building : MonoBehaviour {
    
    void Start() {
        var nmo = GetComponent<NavMeshObstacle>();
        nmo.carving = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
