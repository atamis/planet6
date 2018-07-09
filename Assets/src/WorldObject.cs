using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldObject : MonoBehaviour {

    public SpriteRenderer sr;

    public Sprite sprite {
        get {
            return sr.sprite;
        }
        set {
            sr.sprite = value;
        }
    }

    private GameObject model;

    public Team team;

    void Awake() {
        model = new GameObject("Model");
        model.transform.parent = gameObject.transform;
        model.transform.localPosition = Layers.ModelEnvironment;
        model.AddComponent<Billboard>();
        model.AddComponent<ModelFollowRotation>();
        sr = model.AddComponent<SpriteRenderer>();
        
    }

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}
}