using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float interval;
    Coroutine coroutine;
    SmoothLightProbe probe;

    void OnEnable() {
        interval = 5;
        probe = gameObject.AddComponent<SmoothLightProbe>();
    }

	// Use this for initialization
	void Start () {
        coroutine = StartCoroutine(PeriodicallySpawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // TODO: randomize this slightly?
    IEnumerator PeriodicallySpawnEnemies() {
        while(true) {
            if (!probe.InLight) {
                var go = new GameObject("Enemy");
                go.transform.position = transform.position;
                go.AddComponent<EnemyUnit>();
            }

            yield return new WaitForSeconds(interval);
        }
    }
}
