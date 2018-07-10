using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
[RequireComponent(typeof(PowerableLightHalo))]
public class LightBuilding : MonoBehaviour {

    // Use this for initialization
    void Start() {
        var wo = GetComponent<WorldObject>();
        // TODO: don't use capacitor sprite for simple light.
        wo.sprite = Main.atlas.GetSprite("capacitor");

        var halo = GetComponent<LightHalo>();
        halo.radius = 5;
    }

    // Update is called once per frame
    void Update () {
	}
}
