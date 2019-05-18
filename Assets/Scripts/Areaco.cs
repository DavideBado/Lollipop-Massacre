using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Areaco : MonoBehaviour   
{
    public GameObject Area1, Area2, Area3, Area4, Area5, Area6;
    List<CellPrefScript> CellPrefs = new List<CellPrefScript>();

    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }

    void InUpdate()
    {
        Cells();
        CellsInArea();
    }

    void Cells()
    {
        CellPrefs = FindObjectsOfType<CellPrefScript>().ToList();
    }
    void CellsInArea()
    {
        foreach (CellPrefScript Cell in CellPrefs)
        {
            if(Cell.transform.position.z <= 3 && Cell.transform.position.x <= 7)
            {
                Cell.transform.parent = Area1.transform;
            }
            else if(Cell.transform.position.z <= 3 && Cell.transform.position.x > 7)
            {
                Cell.transform.parent = Area2.transform;
            } else if (Cell.transform.position.z > 3 && Cell.transform.position.z <= 7 && Cell.transform.position.x <= 7)
            {
                Cell.transform.parent = Area3.transform;
            }
            else if (Cell.transform.position.z > 3 && Cell.transform.position.z <= 7 && Cell.transform.position.x > 7)
            {
                Cell.transform.parent = Area4.transform;
            }
            else if (Cell.transform.position.z > 7 && Cell.transform.position.z <= 11 && Cell.transform.position.x <= 7)
            {
                Cell.transform.parent = Area5.transform;
            }
            else if (Cell.transform.position.z > 7 && Cell.transform.position.z <= 11 && Cell.transform.position.x > 7)
            {
                Cell.transform.parent = Area6.transform;
            }            
        }
        gameObject.SetActive(false);
    }
}
