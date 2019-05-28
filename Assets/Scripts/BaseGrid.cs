using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GridSystem {

    public class BaseGrid : MonoBehaviour {
        public List<CellPrefScript> PrefScripts = new List<CellPrefScript>();
        List<Wall> walls = new List<Wall>();
        public GridConfigData ConfigData;
        [SerializeField]
        protected GameObject CellPrefab;
        private bool wallscheck = false;

        protected List<CellPrefScript> Cells = new List<CellPrefScript>();
        List<GameObject> Objects = new List<GameObject>();
       
        void Start() {
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
                    GameObject _Cell = Instantiate(CellPrefab, cellToAdd.worldPosition, Quaternion.identity);
                    PrefScripts.Add(_Cell.GetComponent<CellPrefScript>());
                }
            }
            
        }

        private void Update()
        {
            if (wallscheck == false && walls.Count != 0)
            {
                ManagerCell(); 
            }
            else
            {
                 walls = FindObjectsOfType<Wall>().ToList();
            }
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

        public void ManagerCell()
        {           
            foreach (Wall _wall in walls)
            {
                foreach (CellPrefScript _cell in PrefScripts)
                {
                    if (_cell.transform.position == _wall.transform.position)
                    {
                        _cell.Free = false;
                    }
                    else _cell.Free = true;
                    Debug.Log("X:" + _cell.x + " Y" + _cell.y + " Free:" + _cell.Free);
                }
            }
            wallscheck = true;
        }
    }}
