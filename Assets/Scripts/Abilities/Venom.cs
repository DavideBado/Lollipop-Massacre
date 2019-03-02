using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Venom : MonoBehaviour
{
    public GameObject Poison;
   public void Ability()
    { if (GetComponent<Agent>().Mana > 0 && GetComponent<Player1>().CanAttack)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.back, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.back * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.back * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.left, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.left * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.left * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.right, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            GetComponent<Agent>().Mana--;
        }
   }

    void PoisonPower(RaycastHit hit)
    {
        Instantiate(Poison, hit.transform);
        hit.transform.GetComponent<LifeManager>().Life -= 2;
        Debug.Log("{0}", hit.transform);
    }
}
