using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BuildingManager {
    private static BuildingManager _instance;
    public static BuildingManager instance {
        get {
            if (_instance == null) {
                _instance = new BuildingManager();
            }
            return _instance;
        }
    }

    public BaseBuilding baseBuilding;

    public BuildingManager() {

    }
}
