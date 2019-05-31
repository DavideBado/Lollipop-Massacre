using UnityEngine;
using System.Collections.Generic;

namespace GridSystem {

    [CreateAssetMenu(fileName = "New Walls config", menuName = "Grid/ConfigWalls", order = 2)]
    public class WallsConfigData : ScriptableObject {
        [SerializeField]
        internal List<Vector3Int> WallsPosition = new List<Vector3Int>();   
    }

}
