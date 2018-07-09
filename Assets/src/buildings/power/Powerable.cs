using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerable : MonoBehaviour {

    private bool _powered;
    public bool powered {
        get {
            if (permanentlyPowered) {
                return true;
            } else {
                return _powered;
            }
        }
        set {
            _powered = value;
        }
    }


    public bool permanentlyPowered;
    private GameObject powerModel;

    public void OnEnable() {
        // Test power fields
        powerModel = new GameObject("PowerModel");
        powerModel.transform.parent = gameObject.transform;
        powerModel.transform.localPosition = Layers.ModelCharacter; // TODO: maybe not the character layer?
        powerModel.transform.localRotation = Quaternion.Euler(0, 0, 0);
        powerModel.layer = 9;
        var collider = powerModel.AddComponent<SphereCollider>();
        collider.radius = 0.25f;
    }

    void OnDestroy() {
        Destroy(powerModel);
    }

	// Use this for initialization
	void Start () {
        powered = false;
        permanentlyPowered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
