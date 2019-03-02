using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickUpsSpawner : MonoBehaviour
{
    public List<GridArea> GridAreas = new List<GridArea>();
    public List<CellPrefScript> cellPrefs = new List<CellPrefScript>();
    public List<Wall> Walls = new List<Wall>();
    List<energyscript> Pickups = new List<energyscript>();
    public GameObject P1, P2;
    int P1AreaID, P2AreaID;
    int RandomList, RandomCell, Counter = 0;
    public GameObject PickUp;
    bool CanSpawn;
    bool Searching;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        InStart();
    }

    // Update is called once per frame
    void Update()
    {

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
        PlayersPlease();
        Pickups = FindObjectsOfType<energyscript>().ToList();
        P1AreaID = P1.GetComponentInParent<GridArea>().AreaID;
        P2AreaID = P2.GetComponentInParent<GridArea>().AreaID;
        Counter = 0;
        RandomList = Random.Range(1, 7);
        Searching = true;
        
        foreach (GridArea Area in GridAreas)
        {
            if (Area.AreaID == RandomList && Area.AreaID != P1AreaID && Area.AreaID != P2AreaID)
            {
                cellPrefs = Area.GetComponentsInChildren<CellPrefScript>().ToList();
                RandomCell = Random.Range(0, cellPrefs.Count);
                foreach (CellPrefScript Cell in cellPrefs)
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
                            foreach (energyscript Pickup in Pickups)
                            {
                                Destroy(Pickup.gameObject);

                            }
                            Instantiate(PickUp, Cell.transform.position, Quaternion.identity);
                           

                            return;
                        }
                        
                    }
                    else Counter++;
                }

            }

        }
        

    }

    void PlayersPlease()
    {
        P1 = FindObjectOfType<Player1>().gameObject;
        P2 = FindObjectOfType<Player2>().gameObject;
    }
}
