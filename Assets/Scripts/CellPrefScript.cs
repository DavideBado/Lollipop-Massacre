using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPrefScript : MonoBehaviour
{
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
        if(other.GetComponent<PlayerData>() != null)
        {
            other.transform.parent = this.transform.parent;
        }
    }
}
