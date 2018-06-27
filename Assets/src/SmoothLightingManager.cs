using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLightingManager : MonoBehaviour {

    MeshFilter mf;
    RenderTexture rt;
    Texture2D lightTex;
    Texture2D blackTex;
    SmoothLightCamera slc;

    public static SmoothLightingManager Create() {
        var go = new GameObject("SmoothLightingManager");
        go.transform.position = new Vector3(0, 2, 0);
        var slm = go.AddComponent<SmoothLightingManager>();

        slm.mf = SimpleQuad.ImmediateAdd(go, 10, 10);

        slm.rt = new RenderTexture(Screen.width, Screen.height, 24);

        slm.slc = SmoothLightCamera.Create(slm.rt);
        //slm.slc.GetComponent<Camera>().targetTexture = slm.rt;

        var renderer = go.GetComponent<MeshRenderer>();

        //renderer.material.shader = Shader.Find("Unlit/Transparent");
        renderer.material.shader = Resources.Load<Shader>("shaders/ShadowShader");
        renderer.material.mainTexture = slm.rt;

        slm.lightTex = Resources.Load<Texture2D>("sprites/light-mask");
        slm.blackTex = createBlackTex();
        
        return slm;
    }

    private static Texture2D createBlackTex() {
        var t = new Texture2D(1, 1);
        var pixels = new Color[] { Color.black };

        t.SetPixels(pixels);
        return t;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RenderTexture.active = rt;
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, Screen.width, 0, Screen.height);
        // new Color(0, 0, 0, 0)
        GL.Clear(true, true, Color.black, 0);

        var pos = Input.mousePosition;
        //var center = new Vector3(Screen.width / 2, Screen.height / 2);
        //var loc = pos - center; ;
        //print(loc);

        var dim = new Vector3(lightTex.width, lightTex.height) * 20;
        


        var rect = new Rect(pos - dim/2, dim);

        var mat = new Material(Shader.Find("Unlit/GreyscaleMask"));
        mat.mainTexture = lightTex;

        Graphics.DrawTexture(rect, lightTex, mat);

        //Graphics.Blit(lightTex, rt, new Vector2(1, 1), loc.normalized);


        GL.PopMatrix();

        RenderTexture.active = null;
    }
}
