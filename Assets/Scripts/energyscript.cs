using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyscript : MonoBehaviour
{

    //public Agent energy;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {     
           if(other.GetComponent<Agent>().Mana == 0)
            {
                other.GetComponent<Agent>().Mana++;
            }
            Destroy(gameObject);

        }

    }
}
