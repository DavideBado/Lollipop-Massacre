using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyscript : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Agent>().Mana == 0)
            {
                other.GetComponent<Agent>().Mana++;
            }
            FindObjectOfType<GameManager>().PickUpTurnCount = 0;
            Destroy(gameObject);          
           
        }

    }
}
