using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class PrintDamageEvents : MonoBehaviour {
    private Damageable damageable;
    void Start() {
        damageable = GetComponent<Damageable>();
        damageable.damaged.AddListener(PrintDamage);
    }

    public void PrintDamage(float damage) {
        print(gameObject.name + " took " + damage + " damage: " + damageable.currentHP + "/" + damageable.maxHP);
    }
}