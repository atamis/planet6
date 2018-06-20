using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenericAgent : MonoBehaviour {

    GameObject model;

    public static GenericAgent Create(Vector3 loc) {
        var go = new GameObject("GenericAgent");
        go.transform.position = loc;

        go.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));


        return go.AddComponent<GenericAgent>();
    }

    NavMeshAgent nma;
    SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        nma = gameObject.AddComponent<NavMeshAgent>();

        model = new GameObject("Model");
        model.transform.parent = gameObject.transform;
        model.transform.localPosition = new Vector3(0, 0, 0);

        sr = model.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("sprites/sprites");
        model.AddComponent<Billboard>();

        nma.destination = new Vector3(10, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray.origin, ray.direction, out hitinfo))
                nma.destination = hitinfo.point;
        }

    }
}
