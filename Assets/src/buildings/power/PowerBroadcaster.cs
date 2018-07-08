using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Powerable))]
public class PowerBroadcaster : MonoBehaviour {

    public float radius = 3;
    private float lastRadius = 1;

    public GameObject powerField;

    public void Start() {

    }

    public void OnEnable() {

        powerField = new GameObject("PowerField");
        powerField.transform.parent = gameObject.transform;
        powerField.transform.localPosition = Layers.ModelCharacter; // TODO: maybe not the character layer?
        powerField.transform.localRotation = Quaternion.Euler(0, 0, 0);
        powerField.layer = 9;

        lastRadius = radius - 1; // Force quad remake in Update()
    }

    public void OnDisable() {
        Destroy(powerField);
        PowerManager.instance.ResetPower();
    }

    public void Update() {


        var powerable = GetComponent<Powerable>();

        if (powerable.powered) {
            radius = 3; // TODO: radius is always 3
            Collider[] hits = Physics.OverlapSphere(powerField.transform.position, radius, 1 << 9);

            foreach (Collider hit in hits) {
                // Get in parent because the collider is on the model
                var hitPowerable = hit.GetComponentInParent<Powerable>();
                if (hitPowerable) {
                    hitPowerable.powered = true;
                }
            }

        } else {
            // "Disable" the field if we aren't powered
            radius = 0;
        }

        if (radius != lastRadius) {
            // TODO: instead of remaking quad, maybe resize?

            // radius * 2 because the size is for 1 side of the quad, which
            // will be the diameter of the circle;
            SimpleQuad.ImmediateAdd(powerField, radius * 2, radius * 2);
            lastRadius = radius;
            var mr = powerField.GetComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Custom/Circle2"));
            mr.material.SetColor("_Color", new Color(0.0f, 0.0f, 1, 0.2f));
            
        }

    }

    public void OnDestroy() {
        Destroy(powerField);
    }
}
