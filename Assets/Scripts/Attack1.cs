using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    public GameManager Manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Manager.CanAttack == true)
        {
            other.GetComponent<LifeManager>().Life--;
            Manager.CanAttack = false;
            this.GetComponent<Collider>().enabled = false;
        }
    }

}
