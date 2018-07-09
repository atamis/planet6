using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Building))]
[RequireComponent(typeof(PowerBroadcaster))]
public class BaseBuilding : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var wo = GetComponent<WorldObject>();
        wo.sprite = Main.atlas.GetSprite("base");

        var nmo = GetComponent<NavMeshObstacle>();
        nmo.size = new Vector3(2.5f, 2.5f, 2.5f);

        var powerable = GetComponent<Powerable>();
        powerable.permanentlyPowered = true;

        var damagable = GetComponent<Damagable>();
        damagable.invulnerable = true;
        damagable.damageCollider.radius = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

}
