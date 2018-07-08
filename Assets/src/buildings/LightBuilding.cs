using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
[RequireComponent(typeof(LightHalo))]
public class LightBuilding : MonoBehaviour {

    Powerable powerable;
    LightHalo lightHalo;

	// Use this for initialization
	void Start () {
        var wo = GetComponent<WorldObject>();
        // TODO: don't use capacitor sprite for simple light.
        wo.sprite = Main.atlas.GetSprite("capacitor");

        powerable = GetComponent<Powerable>();
        lightHalo = GetComponent<LightHalo>();
    }

    // Update is called once per frame
    void Update () {
		if (powerable.powered) {
            lightHalo.radius = 5;
        } else {
            lightHalo.radius = 0;
        }
	}
}
