using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Whirlwind : MonoBehaviour
{
    public float Timer;
    private float m_timer;
    private float m_timer2;
    bool onAttack, canUpdateAbility;

    GameManager manager;
    VFXController myVFXController;
    RaycastHit hit;

    private void Start()
    {
        onAttack = false;
        m_timer = 2;
        m_timer2 = Timer;
        manager = FindObjectOfType<GameManager>();
        myVFXController = GetComponentInChildren<VFXController>();
    }

    private void Update()
    {
        if (onAttack == true)
        {
            m_timer -= Time.deltaTime;
            manager.Pause = true;
            manager.TimerOn = false;
            NewPreview(manager.CellAttackMaterial);
            if (m_timer <= 0)
            {
                if (canUpdateAbility)
                {
                    canUpdateAbility = false;
                    int EnemyID = hit.transform.GetComponent<Agent>().PlayerID;
                    hit.transform.gameObject.SetActive(false);
                    hit.transform.position = new Vector3();
                    hit.transform.parent = manager.BenchPOne.transform;
                    if (EnemyID == 1)
                    {
                        ChangePg(manager.POneParty, EnemyID);
                    }
                    else if (EnemyID == 2)
                    {
                        ChangePg(manager.PTwoParty, EnemyID);
                    }
                    manager.CleanTiles();
                    manager.UpdateTilesMat();
                }
                m_timer2 -= Time.deltaTime;
                if (m_timer2 <= 0)
                {
                    onAttack = false;
                    manager.Pause = false;
                    manager.TimerOn = true;
                    m_timer = 2;
                    m_timer2 = Timer;
                    foreach (GameObject _AbilityVFX in myVFXController.AbilityVFX)
                    {
                        _AbilityVFX.SetActive(false);
                        _AbilityVFX.transform.parent = null;
                        _AbilityVFX.transform.parent = myVFXController.transform;
                        _AbilityVFX.transform.position = Vector3.zero;
                    }
                }
            }
        }
    }

    public void Ability()
    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 6 && GetComponent<Agent>().ImStunned == false && manager.CanAttack == true && manager.Pause == false)
        {
            GetComponentInChildren<AnimationController>().Ability();
            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 4))
            {
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

                if (hit.transform.GetComponent<Agent>() != null && hit.transform != transform)
                {
                    foreach (GameObject _AbilityVFX in myVFXController.AbilityVFX)
                    {
                        _AbilityVFX.SetActive(true);
                        _AbilityVFX.transform.parent = null;
                        _AbilityVFX.transform.position = new Vector3(hit.transform.position.x, 1, hit.transform.position.z);
                    }
                    canUpdateAbility = true;
                    onAttack = true;
                    Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<LifeManager>().DamageAmount = 1;
                    hit.transform.GetComponent<LifeManager>().Enemy = GetComponent<Agent>();
                    hit.transform.GetComponent<LifeManager>().BaseAttack = false;
                    GetComponentInChildren<AnimationController>().Enemy = hit.transform.GetComponent<LifeManager>();
                }
            }

            GetComponent<Agent>().Mana--;
            manager.CanAttack = false;
        }

    }

    //public void Preview()
    //{
    //    Manager.UpdateTilesMat();
    //    if (GetComponent<Agent>().MyTurn && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

    //    {
    //        //CleanPreview();
    //        Material PrevMaterial = FindObjectOfType<CellPrefScript>().Materials[3];
    //        NewPreview(PrevMaterial);
    //    }
    //    Manager.UpdateTilesMat();
    //}

    void NewPreview(Material _material)
    {
        float _lookX = GetComponent<Agent>().SavedlookAt.x;
        float _lookY = GetComponent<Agent>().SavedlookAt.z;
        Vector3 playerPosition = transform.position;

        List<CellPrefScript> cells = new List<CellPrefScript>();

        cells = FindObjectsOfType<CellPrefScript>().ToList();

        RaycastHit hit;

        if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 4))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            if (_lookX != 0)
            {

                CellsGreenInRay(new Vector3((transform.position.x + (5 * _lookX)), 0, transform.position.z), cells, playerPosition, null, _material);
            }
            else if (_lookY != 0)
            {
                CellsGreenInRay(new Vector3(transform.position.x, 0, (transform.position.z + (5 * _lookY))), cells, playerPosition, null, _material);
            }
        }
    }
    public void CleanPreview()
    {
        List<CellPrefScript> cells = new List<CellPrefScript>();

        cells = FindObjectsOfType<CellPrefScript>().ToList();

        foreach (CellPrefScript cell in cells)
        {
            cell.GetComponent<MeshRenderer>().material = cell.Materials[0];
        }
    }

    void CellsGreenInRay(Vector3 HitPosition, List<CellPrefScript> cells, Vector3 playerPosition, Agent _agent, Material _material)
    {
        foreach (CellPrefScript cell in cells)
        {
            if (_agent != null)
            {
                if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x <= HitPosition.x) ||
                 (playerPosition.x > cell.transform.position.x && cell.transform.position.x >= HitPosition.x)) &&
                 (Mathf.Round(cell.transform.position.z) == Mathf.Round(HitPosition.z))) ||
                 (((playerPosition.z < cell.transform.position.z && cell.transform.position.z <= HitPosition.z) |
                 (playerPosition.z > cell.transform.position.z && cell.transform.position.z >= HitPosition.z)) &&
                 (Mathf.Round(cell.transform.position.x) == Mathf.Round(HitPosition.x))))
                {
                    cell.GetComponent<MeshRenderer>().material = _material;
                }
            }
            else if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x < HitPosition.x) ||
                 (playerPosition.x > cell.transform.position.x && cell.transform.position.x > HitPosition.x)) &&
                 (Mathf.Round(cell.transform.position.z) == Mathf.Round(HitPosition.z))) ||
                 (((playerPosition.z < cell.transform.position.z && cell.transform.position.z < HitPosition.z) ||
                 (playerPosition.z > cell.transform.position.z && cell.transform.position.z > HitPosition.z)) &&
                 (Mathf.Round(cell.transform.position.x) == Mathf.Round(HitPosition.x))))
            {
                cell.GetComponent<MeshRenderer>().material = _material;
            }
        }
    }

    void ChangePg(List<GameObject> _m_agents, int _OtherPlayerID)
    {
        Transform _Bench = null;
        Vector3 m_SpawnPoint = manager.RespawnController.FindAGoodPoint(GetComponent<PlayerData>());
        if (_OtherPlayerID == 1)
        {
            _Bench = manager.BenchPOne.transform;
        }
        else if (_OtherPlayerID == 2)
        {
            _Bench = manager.BenchPTwo.transform;
        }
        if (_m_agents.Count > 0)
        {
            GameObject _chara = _m_agents[0];
            _m_agents.Remove(_chara);
            _m_agents.Add(_chara);
            SetNewPosition(_chara, m_SpawnPoint);
            ToggleObject(_chara, _Bench);
            foreach (GameObject _AbilityVFX in myVFXController.AbilityVFX)
            {
                _AbilityVFX.transform.parent = null;
                _AbilityVFX.transform.position = new Vector3(_chara.transform.position.x, 1, _chara.transform.position.z);
            }
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
        //_goBench.GetChild(_go.transform.GetSiblingIndex()).gameObject.SetActive(true);

        _go.SetActive(true);
        _go.GetComponent<LifeManager>().DamageAmount = 1;
        _go.GetComponent<LifeManager>().Enemy = GetComponent<Agent>();
        _go.GetComponent<LifeManager>().BaseAttack = false;
        GetComponentInChildren<AnimationController>().Enemy = _go.GetComponent<LifeManager>();
    }
}

