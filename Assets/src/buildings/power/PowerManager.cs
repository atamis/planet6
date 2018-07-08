using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class PowerManager {
    private static PowerManager _instance;
    public static PowerManager instance {
        get {
            if (_instance == null) {
                _instance = new PowerManager();
            }
            return _instance;
        }
    }

    public PowerManager() {

    }

    public void ResetPower() {
        Powerable[] powerables = UnityEngine.Object.FindObjectsOfType<Powerable>();

        foreach (var powerable in powerables) {
            powerable.powered = false;
        }
    }
}