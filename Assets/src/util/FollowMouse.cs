using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo)) {
            transform.position = new Vector3(hitinfo.point.x, Layers.Environment, hitinfo.point.z);
        }
    }
}
