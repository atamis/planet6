using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damagable))]
public class PrintDamageEvents : MonoBehaviour {
    private Damagable damageable;
    void Start() {
        damageable = GetComponent<Damagable>();
        damageable.damaged.AddListener(PrintDamage);
    }

    public void PrintDamage(float damage) {
        print(gameObject.name + " took " + damage + " damage: " + damageable.currentHP + "/" + damageable.maxHP);
    }
}