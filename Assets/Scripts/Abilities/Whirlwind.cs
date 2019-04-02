using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Whirlwind : MonoBehaviour
{
    GameManager Manager;
    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }
    public void Ability()

    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 6 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

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

                    if (EnemyID == 1)
                    {
                        ChangePg(Manager.POneParty, EnemyID);
                        hit.transform.position = new Vector3();
                        hit.transform.parent = Manager.BenchPOne.transform;
                        hit.transform.gameObject.SetActive(false);

                    }
                    else if (EnemyID == 2)
                    {
                        ChangePg(Manager.PTwoParty, EnemyID);
                        hit.transform.position = new Vector3();
                        hit.transform.parent = Manager.BenchPTwo.transform;
                        hit.transform.gameObject.SetActive(false);
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

    public void Preview()
    {

        if (GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 6 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

        {
            CleanPreview();
            float _lookX = GetComponent<Agent>().SavedlookAt.x;
            float _lookY = GetComponent<Agent>().SavedlookAt.z;
            Vector3 playerPosition = transform.position;

            List<CellPrefScript> cells = new List<CellPrefScript>();

            cells = FindObjectsOfType<CellPrefScript>().ToList();

            RaycastHit hit;

            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 4))
            {
                CellsGreenInRay(hit.transform.position, cells, playerPosition);
            }
            else
            {
                if (_lookX != 0)
                {

                    CellsGreenInRay(new Vector3((transform.position.x + (5 * _lookX)), 0, transform.position.z), cells, playerPosition);
                }
                else if (_lookY != 0)
                {
                    CellsGreenInRay(new Vector3(transform.position.x, 0, (transform.position.z + (5 * _lookY))), cells, playerPosition);
                }

            }
        }
    }
    public void CleanPreview()
    {
        List<CellPrefScript> cells = new List<CellPrefScript>();

        cells = FindObjectsOfType<CellPrefScript>().ToList();

        foreach (CellPrefScript cell in cells)
        {
            cell.GetComponentInParent<CellPrefScript>().Color = cell.GetComponentInParent<CellPrefScript>().BaseColor;
        }
    }

    void CellsGreenInRay(Vector3 HitPosition, List<CellPrefScript> cells, Vector3 playerPosition)
    {
        foreach (CellPrefScript cell in cells)
        {
            if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x < HitPosition.x)

                ||

               (playerPosition.x > cell.transform.position.x && cell.transform.position.x > HitPosition.x)) &&


               (cell.transform.position.z == HitPosition.z)) ||



               (((playerPosition.z < cell.transform.position.z && cell.transform.position.z < HitPosition.z) ||
               (playerPosition.z > cell.transform.position.z && cell.transform.position.z > HitPosition.z)) &&
               (cell.transform.position.x == HitPosition.x)))
            {
                cell.GetComponentInParent<CellPrefScript>().Color = Color.green;
            }
        }
    }

    void ChangePg(List<GameObject> _m_agents, int _OtherPlayerID)
    {
        Transform _Bench = null;
        Vector3 m_SpawnPoint = Manager.RespawnController.FindAGoodPoint(GetComponent<PlayerData>());
        if (_OtherPlayerID == 1)
        {
            _Bench = Manager.BenchPOne.transform;
        }
        else if (_OtherPlayerID == 2)
        {
            _Bench = Manager.BenchPTwo.transform;
        }
        if (_m_agents.Count > 0)
        {

            GameObject _chara = _m_agents[0];
            _m_agents.Remove(_chara);
            _m_agents.Add(_chara);

            SetNewPosition(_chara, m_SpawnPoint);

            ToggleObject(_chara, _Bench);
           
            //_chara.GetComponent<LifeManager>().Life -= 2;
        }
    }

    void SetNewPosition(GameObject _agent, Vector3 _SpawnPoint)
    {

        _agent.GetComponent<Agent>().AgentParent = null;
         _agent.GetComponent<Agent>().AgentSpawnPosition = _SpawnPoint;
        //_agent.GetComponent<Agent>().x = (int)_SpawnPoint.x;
        //_agent.GetComponent<Agent>().x2 = (int)_SpawnPoint.x;
        //_agent.GetComponent<Agent>().y = (int)_SpawnPoint.z;
        //_agent.GetComponent<Agent>().y2 = (int)_SpawnPoint.z;
    }


    void ToggleObject(GameObject _go, Transform _goBench)
    {
        _goBench.GetChild(_go.transform.GetSiblingIndex()).gameObject.SetActive(true);

        _go.SetActive(true);
        Debug.Log(_go.name);

    }
}

