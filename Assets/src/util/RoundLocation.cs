using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundLocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var oldpos = transform.position;

        transform.position = new Vector3(Mathf.Round(oldpos.x), oldpos.y, Mathf.Round(oldpos.z));
	}
}
