using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GridSystem {

    public class BaseGrid : MonoBehaviour {
        protected List<CellPrefScript> PrefScripts = new List<CellPrefScript>();
        List<Wall> walls = new List<Wall>();
        public GridConfigData ConfigData;
        public WallsConfigData ConfigWalls;
        [SerializeField]
        protected GameObject CellPrefab;
        private bool wallscheck = false;

        protected List<CellPrefScript> Cells = new List<CellPrefScript>();
        List<GameObject> Objects = new List<GameObject>();
       
        void Start()
        {
            CreateGrid(ConfigData);
        }

        #region API
     
        public void CreateGrid(GridConfigData _configData) {
            // iterazione per la dimensione X della griglia
            for (int x = 0; x < _configData.DimX; x++) {
                // iterazione per la dimensione Y della griglia
                for (int y = 0; y < _configData.DimY; y++) {
                    CellPrefScript cellToAdd = new CellPrefScript(x, y, new Vector3(
                        transform.position.x + (x * _configData.CellDim),
                        0,
                        transform.position.z + (y * _configData.CellDim)
                        ), true);                 
                    Cells.Add(cellToAdd);
                    //GameObject _Cell = Instantiate(CellPrefab, cellToAdd.worldPosition, Quaternion.identity);
                    PrefScripts.Add(Instantiate(CellPrefab, cellToAdd.worldPosition, Quaternion.identity).GetComponent<CellPrefScript>());
                }
            }            
                    ManagerCell(ConfigWalls);
        }       

        public Vector3 GetWorldPosition(int _x, int _y) {
            foreach (CellPrefScript cell in Cells) {
                if (cell.x == _x && cell.y == _y) {
                    return cell.worldPosition;
                }
            }
            return Vector3.zero;
        }

        public CellPrefScript GetCell(int _x, int _y)
        {
            foreach (CellPrefScript cell in Cells)
            {
                if (cell.x == _x && cell.y == _y)
                {
                    return cell;
                }
            }
            return null;
        }

        #endregion

        public void ManagerCell(WallsConfigData _WallsData)
        {
            List<CellPrefScript> _CellsPref = new List<CellPrefScript>(); 
            foreach (Vector3 _wall in _WallsData.WallsPosition)
            {
                foreach (CellPrefScript _cell in PrefScripts)
                {
                    if ((int)_cell.transform.position.x == _wall.x && (int)_cell.transform.position.z == _wall.z)
                    {
                        _cell.Free = false;
                    }
                    else
                    {
                        _cell.Free = true;
                    }

                    _CellsPref.Add(_cell);
                    Debug.Log("X:" + _cell.transform.position.x + " Y" + _cell.transform.position.z + " Free:" + _cell.Free);
                }
                PrefScripts = _CellsPref;
            }
            wallscheck = true;
        }

        public List<CellPrefScript> SendCells()
        {
            return PrefScripts;
        }
    }
}
