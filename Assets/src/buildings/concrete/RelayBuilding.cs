using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
[RequireComponent(typeof(PowerBroadcaster))]
[RequireComponent(typeof(PowerableLightHalo))]
public class RelayBuilding : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var wo = GetComponent<WorldObject>();
        wo.sprite = Main.atlas.GetSprite("relay");

        var lightHalo = GetComponent<LightHalo>();
        lightHalo.radius = 3.5f;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
