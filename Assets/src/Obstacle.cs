using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle {

    GameObject model;

    public static GameObject Create(Vector3 loc) {
        var go = new GameObject("Obstacle");
        go.transform.position = loc;

        var wo = go.AddComponent<WorldObject>();
        wo.sprite = Main.atlas.GetSprite("temp-rock");

        var nmo = go.AddComponent<NavMeshObstacle>();
        nmo.carving = true;
        nmo.size = new Vector3(0.5f, 0.5f, 0.5f);


        return go;
    }
    
}
