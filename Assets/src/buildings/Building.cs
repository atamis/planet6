using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WorldObject))]
[RequireComponent(typeof(NavMeshObstacle))]
[RequireComponent(typeof(Powerable))]
[RequireComponent(typeof(Damageable))]
[RequireComponent(typeof(BlinkOnDamage))]
public class Building : MonoBehaviour {

    private Damageable damageable;

    void OnEnable() {
        var nmo = GetComponent<NavMeshObstacle>();
        nmo.carving = false;

        var wo = GetComponent<WorldObject>();
        wo.team = Team.Player;

        damageable = GetComponent<Damageable>();
    }
	
	// Update is called once per frame
	void Update () {
	}

}
