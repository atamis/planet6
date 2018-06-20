using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;


public class Ground : MonoBehaviour {
    /*
     * TODO: bake obstacles into level mesh, see https://catlikecoding.com/unity/tutorials/procedural-grid/.
     **/


    NavMeshSurface nms;

    public static Ground Create() {
        var go = new GameObject("Ground");
        var ground = go.AddComponent<Ground>();


        SimpleQuad.ImmediateAdd(go, 20, 20);

        // MeshCollider has trouble with local scale changes, even when added after the scale changes.
        go.AddComponent<MeshCollider>();

        ground.nms = go.AddComponent<NavMeshSurface>();

        ground.nms.BuildNavMesh();
        
        return ground;
    }
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
