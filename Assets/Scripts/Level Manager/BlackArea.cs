using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BlackArea : MonoBehaviour
{
    List<CellPrefScript> cellPrefs = new List<CellPrefScript>();
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        cellPrefs = GetComponentsInChildren<CellPrefScript>().ToList();
        foreach (CellPrefScript cell in cellPrefs)
        {
            cell.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
