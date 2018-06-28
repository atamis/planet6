using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Make a model follow it's parent's Y angle rotation.
 * Currently used to make sprite models follow their navmesh
 * parents. Uses Quaternion eulers.
 */
public class ModelFollowRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var curRot = gameObject.transform.rotation;
        var parentRot = gameObject.transform.parent.rotation;

        var curEurlers = curRot.eulerAngles;
        var parentEurlers = parentRot.eulerAngles;

        gameObject.transform.rotation = Quaternion.Euler(curEurlers.x, parentEurlers.y, curEurlers.z);
	}
}
