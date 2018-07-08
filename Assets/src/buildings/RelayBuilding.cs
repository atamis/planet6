using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
public class RelayBuilding : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var wo = GetComponent<WorldObject>();
        wo.sprite = Main.atlas.GetSprite("relay");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
