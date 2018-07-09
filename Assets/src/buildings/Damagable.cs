using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DamagedEvent : UnityEvent<float> { }


public class Damagable : MonoBehaviour {

    public DamagedEvent damaged;

    public float currentHP;

    private float _maxHP;
    public float maxHP {
        get {
            return _maxHP;
        }
        set {
            // Scale current HP 
            float p = currentHP / _maxHP;
            _maxHP = value;
            currentHP = _maxHP * p;
        }
    }

    // Also implies undying.
    public bool invulnerable;

    public void InflictDamage(float damage) {
        if (!invulnerable) {
            currentHP -= damage;
            damaged.Invoke(damage);
        }
    }

    public bool IsDead() {
        if (invulnerable) {
            return false;
        } else {
            return currentHP < 1;
        }
    }

    void OnEnable() {
        currentHP = 10;
        // private so as not to incur weird race conditions
        // can you even have race conditions in single threaded code?
        _maxHP = 10;
        invulnerable = false;
    }

	// Use this for initialization
	void Start () {
        damaged = new DamagedEvent();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
