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
        lightModel.AddComponent<SphereCollider>();

        lastRadius = radius - 1; // Force quad remake in Update()
    }

    public void OnDisable() {
        Destroy(lightModel);
    }

    public void Update() {
        if (radius != lastRadius) {
            SimpleQuad.ImmediateAdd(lightModel, radius, radius);
            lastRadius = radius;
            var mr = lightModel.GetComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Custom/Circle2"));

            var mf = lightModel.GetComponent<MeshFilter>();
            var mc = lightModel.GetComponent<SphereCollider>();
            mc.radius = radius / 2; // TODO: Because lighthalo's "radius" is actually a diameter (see powerbroadcaster);
            //mc.sharedMesh = mf.sharedMesh;
            // TODO: this causes a "cleaning the mesh failed" error
            // sometimes. This is related to 0 size meshes (like when
            // the lighthalo radius is 0), but a fix is not immediately
            // apparent.
        }
    }

    public void OnDestroy() {
        Destroy(lightModel);
    }
}
