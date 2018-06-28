using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLightProbe : MonoBehaviour {

    public GameObject lightProbe;
    public bool inLight = false;
    public float radius = 0.2f;

    // Use this for initialization
    void Start() {

    }

    void OnEnable() {
        lightProbe = new GameObject("Light Probe");
        lightProbe.transform.parent = gameObject.transform;
        lightProbe.transform.localPosition = Layers.ModelCharacter; // TODO: maybe not the character layer?
        lightProbe.transform.localRotation = Quaternion.Euler(0, 0, 0);
        lightProbe.layer = 8;
    }

    void OnDisable() {
        Destroy(lightProbe);
        inLight = false;
    }

	// Update is called once per frame
	void Update () {
        // TODO: run this less for performance reasons?
        // TODO: take into account global light.
        inLight = Physics.CheckSphere(lightProbe.transform.position, radius, 1 << 8);
	}
}
