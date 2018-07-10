using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LightHalo))]
[RequireComponent(typeof(Powerable))]
public class PowerableLightHalo : MonoBehaviour {

    Powerable powerable;
    LightHalo lightHalo;

    private float oldRadius;

    // Use this for initialization
    void Start () {
        powerable = GetComponent<Powerable>();
        lightHalo = GetComponent<LightHalo>();
        oldRadius = lightHalo.radius;
    }
	
	// Update is called once per frame
	void Update () {
        // TODO: maybe make disabling a light easier?
        // TODO: How will this interact with flickering?
        if (lightHalo.radius != 0) {
            oldRadius = lightHalo.radius;
        }

        if (powerable.powered) {
            lightHalo.radius = oldRadius;
        } else {
            lightHalo.radius = 0;
        }
    }
}
