using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    public GameManager Manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Manager.CanAttack == true) // Se è in collisione con un player e può attaccare
        {
            other.GetComponent<LifeManager>().Life-=2; // Togli vita al player in collisione
            Manager.CanAttack = false; // Non posso più attaccare
            this.GetComponent<Collider>().enabled = false; // Spegni il collider di attacco
        }
    }

}
