using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLightIndicator : MonoBehaviour {

    public Texture2D onTex;
    public Texture2D offTex;

    private MeshFilter mf;
    private SmoothLightProbe probe;

    public static VisualLightIndicator Create(Vector3 loc) {
        var go = new GameObject("Visual Light Indicator");
        go.transform.position = loc;

        return go.AddComponent<VisualLightIndicator>();
    }

	// Use this for initialization
	void Start () {
        probe = gameObject.AddComponent<SmoothLightProbe>();

        mf = SimpleQuad.ImmediateAdd(gameObject, 0.5f, 0.5f);

        onTex = Texture2D.whiteTexture;
        offTex = Texture2D.blackTexture;
    }
	
	// Update is called once per frame
	void Update () {
        var mr = GetComponent<MeshRenderer>();
		if (probe.InLight) {
            mr.material.mainTexture = onTex;
        } else {
            mr.material.mainTexture = offTex;
        }
    }
}
