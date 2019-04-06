using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wall : MonoBehaviour
{

    public List<GameObject> Models = new List<GameObject>();

    public ItemData GetData()
    {
        ItemData itemData = new ItemData()
        {
            GridPosition = transform.position,
            ItemType = ItemData.Type.Wall,
        };

        return itemData;
    }


    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.GetComponent<wallModelReference>() != null)
        {
            Models.Add(other.gameObject);
            other.collider.enabled = false;
          
        }
    }
    
}

