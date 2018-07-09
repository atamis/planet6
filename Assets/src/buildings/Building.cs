using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WorldObject))]
[RequireComponent(typeof(NavMeshObstacle))]
[RequireComponent(typeof(Powerable))]
public class Building : MonoBehaviour {
    
    void OnEnable() {
        var nmo = GetComponent<NavMeshObstacle>();
        nmo.carving = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
