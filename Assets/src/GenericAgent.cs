using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenericAgent : MonoBehaviour {

    GameObject model;
    GameObject lightModel;

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


        model = new GameObject("Model");
        model.transform.parent = gameObject.transform;
        model.transform.localPosition = Layers.ModelCharacter;

        sr = model.AddComponent<SpriteRenderer>();
        sr.sprite = Main.atlas.GetSprite("legacy-player");
        model.AddComponent<Billboard>();
        model.AddComponent<ModelFollowRotation>();

        lightModel = new GameObject("LightModel");
        lightModel.transform.parent = gameObject.transform;
        lightModel.transform.localPosition = Layers.ModelCharacter;
        lightModel.transform.localRotation = Quaternion.Euler(0, 0, 0);
        var mf = SimpleQuad.ImmediateAdd(lightModel, 2, 2);
        var mr = lightModel.GetComponent<MeshRenderer>();
        mr.material = new Material(Shader.Find("Custom/Circle2"));
        lightModel.layer = 8;


        /*
         * Adjust speed, massively increase angular speed, consider acceleration.
         */
        nma = gameObject.AddComponent<NavMeshAgent>();
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
