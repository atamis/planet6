using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WorldObject))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyUnit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var wo = GetComponent<WorldObject>();
        wo.sprite = Main.atlas.GetSprite("enemy");

        var nma = GetComponent<NavMeshAgent>();
        nma.radius = 0.2f;
        nma.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 10 == 0) {
            var nma = GetComponent<NavMeshAgent>();
            if (nma.destination != null
                && BuildingManager.instance.baseBuilding != null) {

                var target = BuildingManager.instance.baseBuilding.gameObject.transform.position;

                nma.destination = target;
            
                // TODO: research what this means, whether it's appropriate or premature optimization,
                // whether 10 is a good distance, and whether this can be dynamically updated.
                if (Vector3.Distance(transform.position, target) < 10) {
                    nma.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
                } else {
                    nma.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
                }
            }
        }
	}
}
