﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldObject))]
[RequireComponent(typeof(Damagable))]
public class BlinkOnDamage : MonoBehaviour {
    private float lerper;
    private SpriteRenderer sr;

    public Color blinkColor;

    void OnEnable() {
        blinkColor = Color.red;
    }

    // Use this for initialization
    void Start () {
        GetComponent<Damagable>().damaged.AddListener(ResetLerper);
        // God I hope there's only 1 sprite
        sr = GetComponentInChildren<SpriteRenderer>();
	}

    void ResetLerper(float _a) {
        lerper = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        lerper -= Time.deltaTime;
        
        sr.color = Color.Lerp(Color.white, blinkColor, lerper);
	}
}
