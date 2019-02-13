using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem {

    public class BaseGrid : MonoBehaviour {

        [SerializeField]
        private GridConfigData configData;

        public GameObject CellPrefab;

        protected List<Cell> Cells = new List<Cell>();
        List<GameObject> Objects = new List<GameObject>();
       
        void Start() {
            CreateGrid(configData);

        }

        #region API

        public void CreateGrid(GridConfigData _configData) {
            // iterazione per la dimensione X della griglia
            for (int x = 0; x < configData.DimX; x++) {
                // iterazione per la dimensione Y della griglia
                for (int y = 0; y < configData.DimY; y++) {
                    Cell cellToAdd = new Cell(x, y, new Vector3(
                        transform.position.x + (x * configData.CellDim),
                        0,
                        transform.position.z + (y * configData.CellDim)
                        ));
                    Cells.Add(cellToAdd);
                    GameObject _Cell = Instantiate(CellPrefab, cellToAdd.worldPosition, Quaternion.identity);
                }
            }
        }

        public Vector3 GetWorldPosition(int _x, int _y) {
            foreach (Cell cell in Cells) {
                if (cell.x == _x && cell.y == _y) {
                    return cell.worldPosition;
                }
            }
            return Vector3.zero;
        }

        public Cell GetCell(int _x, int _y)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.x == _x && cell.y == _y)
                {
                    return cell;
                }
            }
            return null;
        }

        #endregion
        private void Update()
        {
            ManagerCell();
        }
        public void ManagerCell()
        {
            GameObject[] PlayerList = GameObject.FindGameObjectsWithTag("Player");
            GameObject[] WallList = GameObject.FindGameObjectsWithTag("Wall");

           
            Debug.Log("Players" + PlayerList.Length);
            Debug.Log("Wall" + WallList.Length);
           
            foreach (Cell cell in Cells)
            {
                foreach (GameObject Object in PlayerList)
                {
                    if (cell.worldPosition == Object.transform.position)
                    {
                        cell.Free = false;
                      //  Debug.Log("X:" + cell.x + " Y" + cell.y + " Free:" + cell.Free);
                    }
                    else cell.Free = true;
                }
                //foreach (GameObject Object in WallList)
                //{
                //    if (cell.worldPosition == Object.transform.position)
                //    {
                //        cell.Free = false;
                //    }
                //    else cell.Free = true;
                //}
               
            }
        }
    }}
