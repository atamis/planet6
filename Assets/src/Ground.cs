using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;


public class Ground : MonoBehaviour {

    public Vector3[] verts;
    public Vector2[] uv;
    public int[] tris;
    Mesh mesh;

    public static Ground Create() {
        var go = new GameObject("Ground");
        var ground = go.AddComponent<Ground>();

        ground.verts = new[]{
            new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 0, 0)
        };

        ground.verts = new[]{
            new Vector3(0, 0, 0), new Vector3(0, 0, 20), new Vector3(20, 0, 0)
        };

        ground.uv = new[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        ground.tris = new int[] { 0, 1, 2};

        var mesh = ground.mesh = new Mesh();

        go.AddComponent<MeshFilter>().mesh = ground.mesh;
        var renderer = go.AddComponent<MeshRenderer>();

        mesh.Clear();

        mesh.vertices = ground.verts;
        mesh.uv = ground.uv;
        mesh.triangles = ground.tris;
        mesh.colors = new Color[] { new Color(0, 0, 0), new Color(0, 0, 0), new Color(1, 1, 1) };
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        renderer.material.mainTexture = makeColorTexture();
        renderer.material.shader = Shader.Find("Unlit/Texture");

        go.AddComponent<MeshCollider>();


        var navSurface = go.AddComponent<NavMeshSurface>();

        navSurface.BuildNavMesh();

        //go.transform.Rotate(new Vector3(-90, 0, 0));

        /*ground.navMeshData = new NavMeshData();
        ground.instance = NavMesh.AddNavMeshData(ground.navMeshData);
        var defaultBuildSettings = NavMesh.GetSettingsByID(0);


        List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();

        var s = new NavMeshBuildSource();
        s.shape = NavMeshBuildSourceShape.Mesh;
        s.sourceObject = mesh;
        s.transform = go.transform.localToWorldMatrix;
        s.area = 0;

        sources.Add(s);

        var bounds = new Bounds(go.transform.position, new Vector3(1, 1, 1));

        NavMeshBuilder.UpdateNavMeshData(ground.navMeshData, defaultBuildSettings, sources, bounds);

    */
        return ground;
    }

    private static Texture2D makeColorTexture() {
        var tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.white);

        return tex;
    }

    NavMeshData navMeshData;
    NavMeshDataInstance instance;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
