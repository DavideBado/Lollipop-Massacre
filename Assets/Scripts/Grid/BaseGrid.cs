using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GridSystem {

    public class BaseGrid : MonoBehaviour {
        protected List<CellPrefScript> PrefScripts = new List<CellPrefScript>();
        protected List<GameObject> InScenePrefScripts = new List<GameObject>();
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

        public void CreateGrid(GridConfigData _configData)
        {
            // iterazione per la dimensione X della griglia
            for (int x = 0; x < _configData.DimX; x++)
            {
                // iterazione per la dimensione Y della griglia
                for (int y = 0; y < _configData.DimY; y++)
                {
                    CellPrefScript cellToAdd = new CellPrefScript(x, y, new Vector3(
                        transform.position.x + (x * _configData.CellDim),
                        0,
                        transform.position.z + (y * _configData.CellDim)
                        ));
                    PrefScripts.Add(cellToAdd);
                    GameObject _Cell = Instantiate(CellPrefab, cellToAdd.worldPosition, Quaternion.identity);
                    //_Cell.GetComponent<CellPrefScript>().x = cellToAdd.x;
                    //_Cell.GetComponent<CellPrefScript>().y = cellToAdd.y;
                    InScenePrefScripts.Add(_Cell);
                }
            }
            ManagerCell(ConfigWalls);           
        }

        public Vector3 GetWorldPosition(int _x, int _y) {
            foreach (CellPrefScript cell in PrefScripts) {
                if (cell.x == _x && cell.z == _y) {
                    return cell.worldPosition;
                }
            }
            return Vector3.zero;
        }

        public CellPrefScript GetCell(int _x, int _y)
        {
            foreach (CellPrefScript cell in Cells)
            {
                if (cell.x == _x && cell.z == _y)
                {
                    return cell;
                }
            }
            return null;
        }

        #endregion

        public void ManagerCell(WallsConfigData _WallsData)
        {
            List<CellPrefScript> _cells = new List<CellPrefScript>();
            foreach (Vector3 _wall in _WallsData.WallsPosition)
            {
                foreach (CellPrefScript _cell in PrefScripts)
                {
                    if ((int)_cell.x == _wall.x && (int)_cell.z == _wall.z)
                    {
                        _cell.Free = false;
                    }
                    else
                    {
                        _cell.Free = true;
                    }
                    _cells.Add(_cell);
                }
            }
            PrefScripts.Clear();
            PrefScripts = _cells;
            SaveInSceneCells();
        }

        private void SaveInSceneCells()
        {
            foreach (CellPrefScript _cell in PrefScripts)
            {
                foreach (GameObject _cellInScene in InScenePrefScripts)
                {
                    if((int)_cellInScene.transform.position.x == _cell.x && (int)_cellInScene.transform.position.z == _cell.z)
                    {
                        _cell.MyCell = _cellInScene;
                    }
                }
            }
        }

        public List<CellPrefScript> SendCells()
        {
            return PrefScripts;
        }

        public bool CellFree(CellPrefScript _cell)
        {
            bool _isFree = true;
            foreach (Vector3 _wall in ConfigWalls.WallsPosition)
            {
                if ((int)_cell.x == _wall.x && (int)_cell.z == _wall.z)
                {
                    _isFree = false;
                }                
            }
            return _isFree;
        }
    }
}
