using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyscript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            Destroy(gameObject);
        }
    }
}
