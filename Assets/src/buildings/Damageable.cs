using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DamagedEvent : UnityEvent<float> { }


public class Damageable : MonoBehaviour {

    public static readonly int DamageableMask = 1 << 10;

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

    private GameObject damageModel;
    public SphereCollider damageCollider;

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

        damageModel = new GameObject("Damage Model");
        damageModel.transform.parent = gameObject.transform;
        damageModel.transform.localPosition = Layers.ModelCharacter; // TODO: maybe not the character layer?
        damageModel.transform.localRotation = Quaternion.Euler(0, 0, 0);
        damageModel.layer = 10;
        damageCollider = damageModel.AddComponent<SphereCollider>();
        damageCollider.radius = 0.25f;

    }

    void OnDestroy() {
        Destroy(damageModel);
    }

    // Use this for initialization
    void Start () {
        damaged = new DamagedEvent();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsDead()) {
            Destroy(gameObject);
        }
    }
}
