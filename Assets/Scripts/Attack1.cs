using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Attack1 : MonoBehaviour
{
    public GameManager Manager;
    

    private void Start()
    {
        
        Manager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Manager.CanAttack == true) // Se è in collisione con un player e può attaccare
        {
            other.GetComponent<LifeManager>().Life-=2; // Togli vita al player in collisione
           
            this.GetComponent<Collider>().enabled = false; // Spegni il collider di attacco


            other.transform.DOShakePosition(0.5f, 0.1f, 10, 45);
        }
    }

}
