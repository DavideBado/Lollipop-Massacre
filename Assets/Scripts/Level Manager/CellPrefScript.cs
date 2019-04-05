using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPrefScript : MonoBehaviour
{
    public List<Material> Materials;
   
    int area;
   
    public ItemData GetData()
    {
        ItemData itemData = new ItemData()
        {
            GridPosition = transform.position,
            ItemType = ItemData.Type.Player,
        };

        return itemData;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerData>() != null)
        {
            other.transform.parent = transform.parent;
            if (other.GetComponent<Agent>().PlayerID == 1)
            {
                GetComponent<MeshRenderer>().material = Materials[1];
            }
            else if (other.GetComponent<Agent>().PlayerID == 2)
            {
                GetComponent<MeshRenderer>().material = Materials[2];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerData>() != null)
        {
            GetComponent<MeshRenderer>().material = Materials[0];

        }


    }
}