using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTransparency : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "EnergyUp")
        {
            foreach(GameObject _object in GetComponentInParent<Wall>().Models)
            {
                _object.GetComponentInParent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            }

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player" || other.gameObject.tag == "EnergyUp")
    //    {
    //        GetComponentInParent<MeshRenderer>().material.color = new Color(1.0f, 0f, 0.7611f, 1f);
    //    }
    //}
}
