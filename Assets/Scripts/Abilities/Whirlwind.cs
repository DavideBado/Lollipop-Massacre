using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : MonoBehaviour
{ GameManager Manager;
    private void Start()
{
    Manager = FindObjectOfType<GameManager>();
}
public void Ability()

{
    if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 6 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true)

    {
        RaycastHit hit;

        if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 4))

        {

            Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

            if (hit.transform.tag == "Player" && hit.transform != transform)

            {

                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                hit.transform.GetComponent<LifeManager>().Life -= 2;
                int EnemyID = hit.transform.GetComponent<Agent>().PlayerID;
               
                    if(EnemyID == 1)
                    {
                        if(Manager.POneParty.Count > 0)
                        {
                            Agent _chara = Manager.POneParty[0];
                            Manager.POneParty.Remove(_chara);
                            _chara.transform.parent = null;
                            _chara.gameObject.SetActive(true);
                            _chara.transform.position =  Manager.RespawnController.FindAGoodPoint();
                           
                            Manager.POneParty.Add(_chara);
                            _chara.GetComponent<LifeManager>().Life -= 2;
                        }
                    }
                    else if (EnemyID == 2)
                    {
                        if (Manager.PTwoParty.Count > 0)
                        {
                            Agent _chara = Manager.PTwoParty[0];
                            _chara.transform.position = Manager.RespawnController.FindAGoodPoint();
                            Manager.PTwoParty.Remove(_chara);
                            _chara.gameObject.SetActive(true);
                            Manager.PTwoParty.Add(_chara);
                            _chara.GetComponent<LifeManager>().Life -= 2;
                        }
                    }
                    hit.transform.gameObject.SetActive(false);
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

