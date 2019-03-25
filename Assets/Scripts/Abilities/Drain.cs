using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drain : MonoBehaviour
{
    GameManager Manager;
    public Agent agent;
    bool imDrained = false;

    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        agent = GetComponent<Agent>();
    }
    public void Ability()
    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 2 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true)
        {
            if(GetComponent<LifeManager>().Life == 6)
            {
                ImFullButIWannaDrain();
            }

            if (GetComponent<LifeManager>().Life < 6)
            {
                INeedLifeDrain();
            }

            if (FindObjectOfType<PickUpsSpawner>().AllManaFull == true)
            {
                FindObjectOfType<GameManager>().PickUpTurnCount = 0;
                FindObjectOfType<PickUpsSpawner>().AllManaFull = false;
            }
            GetComponent<Agent>().Mana--;
            Manager.CanAttack = false;
            agent.DrainPS.SetActive(true);
            agent.StartDrain = Manager.Turn;
        }        
    }
    void ImFullButIWannaDrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                hit.transform.GetComponent<LifeManager>().Life-=2;
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }
    }

    void INeedLifeDrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
        {
            Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                if (GetComponent<LifeManager>().Life == 5)
                {
                    GetComponent<LifeManager>().Life++;
                }
                else if (GetComponent<LifeManager>().Life < 5)
                {
                    GetComponent<LifeManager>().Life += 2;
                }
                hit.transform.GetComponent<LifeManager>().Life -= 2;
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }
        if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
        {
            Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                GetComponent<LifeManager>().Life += 2;
                hit.transform.GetComponent<LifeManager>().Life -= 2;
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }
        if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
        {
            Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                GetComponent<LifeManager>().Life += 2;
                hit.transform.GetComponent<LifeManager>().Life -= 2;
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }

    }

}
