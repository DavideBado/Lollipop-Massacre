using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    GameManager Manager;
    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }
    public void Ability()

    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 5 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true)

        {

            RaycastHit hit;

            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, Mathf.Infinity))

            {
                if(hit.transform.position.x == transform.position.x)
                {
                    int dist = (GetComponent<Agent>().y - (int)hit.transform.position.z);

                    if (dist < 0)
                    {
                        GetComponent<Agent>().y = (int)hit.transform.position.z - 1;
                    }
                    else if (dist > 0)
                    {
                        GetComponent<Agent>().y = (int)hit.transform.position.z + 1;
                    }
                    Manager.TimerOn = false;
                    GetComponent<Agent>().OnTheRoad = true;
                    GetComponent<Agent>().AgentSpeed = 5;
                }
                else
                    if (hit.transform.position.z == transform.position.z)
                {
                    int dist = (GetComponent<Agent>().x - (int)hit.transform.position.x);

                    if (dist < 0)
                    {
                        GetComponent<Agent>().x = (int)hit.transform.position.x - 1;
                    }
                    else if (dist > 0)
                    {
                        GetComponent<Agent>().x = (int)hit.transform.position.x + 1;
                    }
                    Manager.TimerOn = false;
                    GetComponent<Agent>().OnTheRoad = true;
                    GetComponent<Agent>().AgentSpeed = 5;
                }
               
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
                
                if (hit.transform.tag == "Player" && hit.transform != transform)

                {
                    int dist = (int)Vector3.Distance(transform.position, hit.transform.position);
                    Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    if (dist < 5)
                    {
                        hit.transform.GetComponent<LifeManager>().Life -= 1;
                    } else if (dist >= 5)
                    {
                        hit.transform.GetComponent<LifeManager>().Life -= 2;
                    }

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

