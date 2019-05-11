using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HealtUpsSpawner : MonoBehaviour
{
    GameManager gameManager;
    public List<GridArea> GridAreas = new List<GridArea>();
    energyscript energy;
    public List<CellPrefScript> cellPrefs = new List<CellPrefScript>();
    public List<Wall> Walls = new List<Wall>();
    List<Healthscript> Pickups = new List<Healthscript>();
    public GameObject P1, P2;
    int P1AreaID, P2AreaID;
    int RandomList, RandomCell, Counter = 0;
    public GameObject PickUp;
    bool CanSpawn;
    bool Searching;
    public bool AllManaFull = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InStart();
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(FindObjectOfType<GameManager>().HealtTurnCount >= 5 && gameManager.TimerOn == false)
        {
            Pickups = FindObjectsOfType<Healthscript>().ToList();
            if (Pickups.Count == 0)
            {
                SpawnHealt();
            }
            else { FindObjectOfType<GameManager>().HealtTurnCount = 0; }
        }
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

    public void SpawnHealt()
    {
        energy = FindObjectOfType<energyscript>();
        if(energy == null)
        {
            energy = new energyscript();
        }
        PlayersPlease();
        //Pickups = FindObjectsOfType<energyscript>().ToList();
        P1AreaID = P1.GetComponentInParent<GridArea>().AreaID;
        P2AreaID = P2.GetComponentInParent<GridArea>().AreaID;
        Counter = 0;
        RandomList = Random.Range(1, 10);
        //Debug.Log("RandomList" + RandomList.ToString());
        Searching = true;
        if (Pickups.Count == 0 /*&& (P1.GetComponent<Agent>().Mana == 0  || P2.GetComponent<Agent>().Mana == 0)*/)
        {
            foreach (GridArea Area in GridAreas)
            {
                if (Area.AreaID == RandomList && Area.AreaID != 5 &&
                    Area.AreaID != P1AreaID && Area.AreaID != (P1AreaID - 3) && Area.AreaID != (P1AreaID + 3) && Area.AreaID != (P1AreaID - 1) && Area.AreaID != (P1AreaID + 1) &&
                    Area.AreaID != P2AreaID && Area.AreaID != (P2AreaID - 3) && Area.AreaID != (P2AreaID + 3) && Area.AreaID != (P2AreaID - 1) && Area.AreaID != (P2AreaID + 1) && 
                    (Area.AreaID != energy.PickupArea))
                {
                    //Debug.Log("AreaID" + Area.AreaID.ToString());
                    cellPrefs = Area.GetComponentsInChildren<CellPrefScript>().ToList();
                    RandomCell = Random.Range(0, cellPrefs.Count);
                    //Debug.Log("RandomCell" + RandomCell.ToString());
                    for (int i = 0; i < cellPrefs.Count; i++)
                    {
                        if (i == RandomCell)
                        {
                            //Debug.Log("Cella" + cellPrefs[i].transform.position.ToString());
                            //Debug.Log("Area della Cella" + cellPrefs[i].GetComponentInParent<GridArea>().AreaID.ToString());
                            CanSpawn = true;

                            foreach (Wall _wall in Walls)
                            {
                                if (_wall.transform.position == cellPrefs[i].transform.position)
                                {
                                    CanSpawn = false;                                   
                                    return;
                                }
                            }
                            if (CanSpawn == true)
                            {
                                //foreach (energyscript Pickup in Pickups)
                                //{
                                //    Destroy(Pickup.gameObject);

                                //}
                                GameObject NewPickUp = Instantiate(PickUp, cellPrefs[i].transform.position, Quaternion.identity);
                                NewPickUp.GetComponent<Healthscript>().PickupArea = Area.AreaID;
                                gameManager.HealtTurnCount = 0;                                
                                return;
                            }
                        }
                    }
                   
                    //foreach (CellPrefScript Cell in cellPrefs)
                    //{
                    //    /*if (RandomCell == Counter)
                    //    {*/
                    //        CanSpawn = true;

                    //        foreach (Wall _wall in Walls)
                    //        {
                    //            if (_wall.transform.position == Cell.transform.position)
                    //            {
                    //                CanSpawn = false;
                    //            }
                    //        }
                    //        if (CanSpawn == true)
                    //        {
                    //            //foreach (energyscript Pickup in Pickups)
                    //            //{
                    //            //    Destroy(Pickup.gameObject);

                    //            //}
                    //            Instantiate(PickUp, Cell.transform.position, Quaternion.identity);


                    //            return;
                    //        }

                    //    //}
                    //    //else Counter++;
                    //}

                }
            }
        }
        else if(P1.GetComponent<Agent>().Mana > 0 && P2.GetComponent<Agent>().Mana > 0)
        {
            //AllManaFull = true;
        }

    }

    void PlayersPlease()
    {
        P1 = FindObjectOfType<Player1>().gameObject;
        P2 = FindObjectOfType<Player2>().gameObject;
    }
}
