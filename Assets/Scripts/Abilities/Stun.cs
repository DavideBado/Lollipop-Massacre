using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    GameManager Manager;
    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }
    public void Ability()
    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 3 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
            {
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<Agent>().ImStunned = true;
                    hit.transform.GetComponent<LifeManager>().Life -= 2;
                }
            }
            if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
            {
                Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<Agent>().ImStunned = true;
                    hit.transform.GetComponent<LifeManager>().Life -= 2;
                }
            }
            if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
            {
                Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<Agent>().ImStunned = true;
                    hit.transform.GetComponent<LifeManager>().Life -= 2;
                }
            }

            if (FindObjectOfType<PickUpsSpawner>().AllManaFull == true)
            {
                FindObjectOfType<GameManager>().PickUpTurnCount = 0;
                FindObjectOfType<PickUpsSpawner>().AllManaFull = false;
            }
            GetComponent<Agent>().Mana--;
            Manager.CanAttack = false;
        }
    }
}
