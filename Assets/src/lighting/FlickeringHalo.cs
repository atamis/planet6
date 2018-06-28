using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LightHalo))]
public class FlickeringHalo : MonoBehaviour {

    private float originalSize;
    private float scale;
    public float delta = 0.5f;
    public float strength = 2f;
    

	// Use this for initialization
	void Start () {
        var lh = GetComponent<LightHalo>();
        delta = originalSize = lh.lightModel.transform.localScale.x;
        
	}
	
	// Update is called once per frame
	void Update () {
        var lh = GetComponent<LightHalo>();
        var model = lh.lightModel;

        scale = Mathf.Lerp(scale, Random.Range(originalSize - delta, originalSize + delta), strength * Time.deltaTime);

        model.transform.localScale = new Vector3(scale, 0, scale);
    }
}
