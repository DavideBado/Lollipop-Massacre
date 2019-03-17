using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPrefScript : MonoBehaviour
{
    bool latestarted = false;
    int area;
    public Color Color, BaseColor;
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
            other.transform.parent = transform.parent;
        }
    }    

    private void Update()
    {
        if(GetComponentInParent<GridArea>() != null && latestarted == false)
        {
            LateStart();
            latestarted = true;
        }
        Colorame();
    }

    void LateStart()
    {
        area = GetComponentInParent<GridArea>().AreaID;
        if (area == 1 || area == 4 || area == 5)
        {
            BaseColor = Color.black;
        }
        else if (area == 2 || area == 3 || area == 6)
        {
            BaseColor = Color.white;
        }

        Color = BaseColor;
    }

    void Colorame()
    {
        GetComponent<MeshRenderer>().material.color = Color;
    }
}
