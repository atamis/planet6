using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class BuildingFactory<T> : IBuildingFactory where T : MonoBehaviour {
    public override String Name() {
        return typeof(T).ToString();
    }

    public override GameObject Instantiate(Vector3 position) {
        var b = new GameObject(Name());
        b.transform.position = position;
        b.AddComponent<T>();

        return b;
    }
}

abstract class IBuildingFactory {
    public abstract String Name();
    public abstract GameObject Instantiate(Vector3 position);
}

class BuildingManager : MonoBehaviour {
    private static BuildingManager _instance;
    public static BuildingManager instance {
        get {
            if (_instance == null) {
                _instance = Main.root.AddComponent<BuildingManager>();
            }
            return _instance;
        }
    }

    public BaseBuilding baseBuilding;

    private IBuildingFactory[] types = { new BuildingFactory<RelayBuilding>(), new BuildingFactory<LaserTurretBuilding>() };
    private Sprite[] sprites;

    private int indicatorIndex;
    private GameObject indicator;

    void OnEnable() {

        sprites = new Sprite[] {
            Main.atlas.GetSprite("relay"),
            Main.atlas.GetSprite("small-turret-base")
        };

        indicatorIndex = -1;
    }

    private GameObject createIndicator() {
        var i = new GameObject("Building Indicator");
        i.AddComponent<FollowMouse>();
        i.AddComponent<RoundLocation>(); // Order matters, round after mouse.
        i.AddComponent<Billboard>();
        var sr = i.AddComponent<SpriteRenderer>();
        sr.sprite = sprites[indicatorIndex];
        sr.color = new Color(0.5f, 0.5f, 1, 0.5f);
        return i;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            Destroy(indicator);
            indicator = null;
            if (indicatorIndex == 0) {
                indicatorIndex = -1;
                return;
            }
            indicatorIndex = 0;
            print("Selected " + types[indicatorIndex].Name());
        }
        if (Input.GetKey(KeyCode.Alpha2)) {
            Destroy(indicator);
            indicator = null;
            if (indicatorIndex == 1) {
                indicatorIndex = -1;
                return;
            }
            indicatorIndex = 1;
            print("Selected " + types[indicatorIndex].Name());
        }

        if (indicatorIndex >= 0) {
            if (!indicator) {
                indicator = createIndicator();
            }

            if (Input.GetMouseButton(0)) {
                var tar = indicator.transform.position;
                // TODO: some other mask, maybe power? It currently ignores 
                Collider[] cs = Physics.OverlapSphere(tar, 0, Damageable.DamageableMask); // TODO: some other mask, maybe power?
                if (cs.Length < 1) {
                    types[indicatorIndex].Instantiate(indicator.transform.position);
                }  else {
                    print("Building blocked by " + cs.Length + " colliders");
                }
            }
        }
    }
}
