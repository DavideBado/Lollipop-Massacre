using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickUpsSpawner : MonoBehaviour
{
    public List<GridArea> GridAreas = new List<GridArea>();
    public List<CellPrefScript> cellPrefs = new List<CellPrefScript>();
    public List<Wall> Walls = new List<Wall>();
    int RandomList, RandomCell, Counter = 0;
    public GameObject PickUp;
    bool CanSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InStart();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAPickUp(); 
    }

    void InStart()
    {
        AreasPlease();
        WallsPlease();
    }

    void AreasPlease()
    {
        GridAreas = FindObjectsOfType<GridArea>().ToList();
    }

    void WallsPlease()
    {
        Walls = FindObjectsOfType<Wall>().ToList();
    }

    public void SpawnAPickUp()
    {
        Counter = 0;
        RandomList = Random.Range(1, 7);
        foreach(GridArea Area in GridAreas)
        {
            if(Area.AreaID == RandomList)
            {
                cellPrefs = Area.GetComponentsInChildren<CellPrefScript>().ToList();
                RandomCell = Random.Range(0, cellPrefs.Count);
                foreach(CellPrefScript Cell in cellPrefs)
                {
                    if (RandomCell == Counter)
                    {
                        CanSpawn = true;
                        
                        foreach (Wall _wall in Walls)
                        {
                            if (_wall.transform.position == Cell.transform.position)
                            {
                                CanSpawn = false;
                            }
                        }
                        if (CanSpawn == true)
                        {
                            Instantiate(PickUp, Cell.transform.position, Quaternion.identity);
                        }
                    }
                    else Counter++;
                }

            }

        }
    }
}
