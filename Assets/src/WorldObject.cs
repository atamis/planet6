using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshObstacle))]
public class WorldObject : MonoBehaviour {

    public Sprite sprite {
        get {
            return model.GetComponent<SpriteRenderer>().sprite;
        }
        set {
            model.GetComponent<SpriteRenderer>().sprite = value;
        }
    }

    private GameObject model;

    void Awake() {
        model = new GameObject("Model");
        model.transform.parent = gameObject.transform;
        model.transform.localPosition = Layers.ModelEnvironment;
        model.AddComponent<Billboard>();
        var sr = model.AddComponent<SpriteRenderer>();

        var nmo = GetComponent<NavMeshObstacle>();
        nmo.carving = true;
        nmo.size = new Vector3(0.5f, 0.5f, 0.5f);
    }

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}
}