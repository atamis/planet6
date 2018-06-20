using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleQuad {

    public static MeshFilter ImmediateAdd(GameObject go, float height, float width) {

        var filter = go.GetComponent<MeshFilter>();
        if (!filter) {
            filter = go.AddComponent<MeshFilter>();
        }
        var renderer = go.GetComponent<MeshRenderer>();
        if (!renderer) {
            renderer = go.AddComponent<MeshRenderer>();
        }

        var verts = new[]{
            new Vector3(0, 0, 0), new Vector3(0, 0, height), new Vector3(width, 0, 0), new Vector3(width, 0, height)
        };
        
        for (int i = 0; i < verts.Length; i++) {
            verts[i] = verts[i] + new Vector3(-width / 2, 0, -height / 2);
        }

        var uv = new[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) };
        var tris = new int[] { 0, 1, 2, 3, 2, 1 };

        var mesh = new Mesh();

        filter.mesh = mesh;

        mesh.Clear();

        mesh.vertices = verts;
        mesh.uv = uv;
        mesh.triangles = tris;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        renderer.material.mainTexture = makeColorTexture();
        renderer.material.shader = Shader.Find("Unlit/Texture");

        return filter;
    }


    private static Texture2D makeColorTexture() {
        var tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.white);

        return tex;
    }
}
