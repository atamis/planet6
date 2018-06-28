using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLightProbe : MonoBehaviour {
    
    public bool InLight {
        get {
            return _inLight;
        }
    }

    [SerializeField]
    private bool _inLight = false;
    public float radius = 0.2f;

    // Use this for initialization
    void Start() {

    }
    
    void OnDisable() {
        _inLight = false;
    }

	// Update is called once per frame
	void Update () {
        // TODO: run this less for performance reasons?
        // TODO: take into account global light.
        _inLight = Physics.CheckSphere(gameObject.transform.position, radius, 1 << 8);
	}
}
