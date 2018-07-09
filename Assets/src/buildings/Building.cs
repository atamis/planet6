using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WorldObject))]
[RequireComponent(typeof(NavMeshObstacle))]
[RequireComponent(typeof(Powerable))]
[RequireComponent(typeof(Damagable))]
public class Building : MonoBehaviour {

    private Damagable damagable;

    void OnEnable() {
        var nmo = GetComponent<NavMeshObstacle>();
        nmo.carving = false;

        var wo = GetComponent<WorldObject>();
        wo.team = Team.Player;

        damagable = GetComponent<Damagable>();
    }
	
	// Update is called once per frame
	void Update () {
		if (damagable.IsDead()) {
            Destroy(gameObject);
        }
	}

}
