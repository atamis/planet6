using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
public class LaserTurretBuilding : MonoBehaviour {

    private Damageable target;

    public float range = 3;
    public float dps = 5;

	// Use this for initialization
	void Start () {
        GetComponent<WorldObject>().sr.sprite = Main.atlas.GetSprite("small-turret-base");
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<Powerable>().powered) {
            return;
        }
        if (target && Vector3.Distance(gameObject.transform.position, target.gameObject.transform.position) > range) {
            target = null;
        }
		if (target) {
            target.InflictDamage(Time.deltaTime * dps);
            return;
        }


        Collider[] hits = Physics.OverlapSphere(transform.position, range, Damageable.DamageableMask);
        if (hits.Length > 0) {
            Collider nearest = null;
            Damageable nearestDamageable = null;
            var dist = 10000f;

            foreach (Collider c in hits) {
                var thisDist = Vector3.Distance(transform.position, c.gameObject.transform.position);
                if (thisDist < dist) {
                    var td = c.gameObject.GetComponentInParent<Damageable>();
                    var wo = c.gameObject.GetComponentInParent<WorldObject>();
                    if (td && wo.team == Team.Enemy) {
                        nearest = c;
                        dist = thisDist;
                        nearestDamageable = td;
                    }
                }
            }
            

            if (nearestDamageable) {
                target = nearestDamageable;
            }
        }
    }
}
