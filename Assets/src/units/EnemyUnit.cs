using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WorldObject))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Damagable))]
public class EnemyUnit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var wo = GetComponent<WorldObject>();
        wo.sprite = Main.atlas.GetSprite("enemy");
        wo.team = Team.Enemy;

        var nma = GetComponent<NavMeshAgent>();
        nma.radius = 0.2f;
        nma.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;

        StartCoroutine(PeriodicallyDealDamage());
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
                // whether 10 is a good distance, and whether this even can be dynamically updated.
                if (Vector3.Distance(transform.position, target) < 10) {
                    nma.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
                } else {
                    nma.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
                }
            }
        }


    }

    IEnumerator PeriodicallyDealDamage() {
        while(true) {
            // TODO: Tune weapon range.
            Collider[] hits = Physics.OverlapSphere(transform.position, 1f, Damagable.DamagableMask);

            if (hits.Length > 0) {
                var col = hits[0];

                // In parent because we just hit the model on layer 10, not the real game object.
                var damageable = col.gameObject.GetComponentInParent<Damagable>();
                var wo = col.gameObject.GetComponentInParent<WorldObject>();

                if (damageable && wo) {
                    if (wo.team != Team.Enemy) {
                        damageable.InflictDamage(1);
                    }
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
