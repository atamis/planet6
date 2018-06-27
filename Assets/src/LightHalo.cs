using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHalo : MonoBehaviour {

    public float radius = 1;
    private float lastRadius = 1;

    public GameObject lightModel;

    public void Start() {
        
    }

    public void OnEnable() {
        lightModel = new GameObject("LightModel");
        lightModel.transform.parent = gameObject.transform;
        lightModel.transform.localPosition = Layers.ModelCharacter; // TODO: maybe not the character layer?
        lightModel.transform.localRotation = Quaternion.Euler(0, 0, 0);
        lightModel.layer = 8;

        lastRadius = radius - 1; // Force quad remake in Update()
    }

    public void OnDisable() {
        Destroy(lightModel);
    }

    public void Update() {
        if (radius != lastRadius) {
            var mf = SimpleQuad.ImmediateAdd(lightModel, radius, radius);
            lastRadius = radius;
            var mr = lightModel.GetComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Custom/Circle2"));
        }
    }

    public void OnDestroy() {
        Destroy(lightModel);
    }
}
