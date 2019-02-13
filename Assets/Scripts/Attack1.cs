using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {if(other.GetComponent<LifeManager>().OnShield == false)
            other.GetComponent<LifeManager>().Life--;
            this.GetComponent<Collider>().enabled = false;
        }
    }
}
