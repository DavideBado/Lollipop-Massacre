using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> POneParty = new List<GameObject>();
    public List<GameObject> PTwoParty = new List<GameObject>();
    public GameObject BenchPOne, BenchPTwo;
    public int PlayerID;
    List<Vector3> CharaPosition = new List<Vector3>();
    /// <summary>
    /// clona lista e istanzia giocatori
    /// </summary>
    public void Setup()
    {
        VectorFill();
        UpdateBench();
    }

    void UpdateBench()
    {
        if (GameManager.singleton.POnePart != null)
        {
            int i = 1;

            foreach (GameObject _Character in GameManager.singleton.POnePart)
            {

                GameObject m_Character = Instantiate(_Character, new Vector3(0, 0, 0), Quaternion.identity, null);
                POneParty.Add(m_Character);
                m_Character.GetComponent<Agent>().SwitchIndex = i;
                i++;
                //Debug.Log(m_Character.activeSelf);

                m_Character.transform.parent = BenchPOne.transform;
                m_Character.SetActive(false);
                //Debug.Log("Dopo" + m_Character.activeSelf);
            }
        }
        if (GameManager.singleton.PTwoPart != null)
        {
            int i = 1;

            foreach (GameObject _Character in GameManager.singleton.PTwoPart)
            {
                GameObject m_Character = Instantiate(_Character, new Vector3(15, 0, 11), Quaternion.identity, null);
                PTwoParty.Add(m_Character);
                m_Character.GetComponent<Agent>().SwitchIndex = i;
                i++;
                m_Character.transform.parent = BenchPTwo.transform;
                m_Character.SetActive(false);
                
            }
        }
        ActiveStarters();
    }

    void ActiveStarters()
    {
        PgInStartPosition(POneParty, 1);
        PgInStartPosition(PTwoParty, 2);
    }

    void PgInStartPosition(List<GameObject> _m_agents, int _PlayerID)
    {
        Transform _Bench = null;

        if (_PlayerID == 1)
        {
            _Bench = BenchPOne.transform;
        }
        else if (_PlayerID == 2)
        {
            _Bench = BenchPTwo.transform;
        }
        if (_m_agents.Count > 0)
        {
            GameObject _chara = _m_agents[0];
            SetNewPosition(_chara, CharaPosition[(_PlayerID - 1)]);
            ToggleObject(_chara, _m_agents);
        }
    }

    void SetNewPosition(GameObject _agent, Vector3 _SpawnPoint)
    {
        _agent.GetComponent<Agent>().AgentParent = null;
        _agent.GetComponent<Agent>().AgentSpawnPosition = _SpawnPoint;
        _agent.GetComponent<Agent>().transform.parent = null;
        _agent.GetComponent<Agent>().transform.position = _SpawnPoint;

    }

    void ToggleObject(GameObject _go, List<GameObject> _m_agents)
    {
        _m_agents.Remove(_go);
        _m_agents.Add(_go);
        _go.SetActive(true);
        // _goBench.GetChild(_go.transform.GetSiblingIndex()).gameObject.SetActive(true);   
    }

    public void VectorFill()
    {
        Vector3 spawn1 = new Vector3(0, 0, 0);
        Vector3 spawn2 = new Vector3(15, 0, 11);
        CharaPosition.Add(spawn1);
        CharaPosition.Add(spawn2);
    }

    public void Switcher(int _PlayerID, int _CharacterIndex, GameObject _ActiveCharacter, bool _RotUp, bool _RotDown, bool _RotRight, bool _RotLeft)
    {
        if (_PlayerID == 1 /*&& m_SwitchPOne > 0*/)
        {

            //m_SwitchPOne--;
            //// Spegnere il personaggio in scena, attivare quello selezionato e metterlo nella stessa posizione di quello appena  
            //foreach (GameObject _Character in POneParty)
            //{
            if (POneParty[_CharacterIndex].GetComponent<LifeManager>().Life > 0)
            {
                GameObject _Character = POneParty[_CharacterIndex];
                _Character.transform.position = _ActiveCharacter.transform.position;
                _Character.GetComponent<Agent>().AgentSpawnPosition = _ActiveCharacter.transform.position;
                _Character.GetComponent<Agent>().RotUp = _RotUp;
                _Character.GetComponent<Agent>().RotDown = _RotDown;
                _Character.GetComponent<Agent>().RotRight = _RotRight;
                _Character.GetComponent<Agent>().RotLeft = _RotLeft;
                POneParty.Remove(_ActiveCharacter);
                POneParty.Insert(_CharacterIndex, _ActiveCharacter);
                ToggleObject(_Character, POneParty);
                _Character.transform.rotation = _ActiveCharacter.transform.rotation;
                _ActiveCharacter.transform.parent = BenchPOne.transform;
                _ActiveCharacter.SetActive(false);
            }
            //}

        }
        else if (_PlayerID == 2 /*&& m_SwitchPTwo > 0*/)
        {
            //m_SwitchPTwo--;
            //foreach (GameObject _Character in PTwoParty)
            //{
            if (PTwoParty[_CharacterIndex].GetComponent<LifeManager>().Life > 0)
            {
                GameObject _Character = PTwoParty[_CharacterIndex];
                _Character.transform.position = _ActiveCharacter.transform.position;
                _Character.GetComponent<Agent>().AgentSpawnPosition = _ActiveCharacter.transform.position;
                _Character.GetComponent<Agent>().RotUp = _RotUp;
                _Character.GetComponent<Agent>().RotDown = _RotDown;
                _Character.GetComponent<Agent>().RotRight = _RotRight;
                _Character.GetComponent<Agent>().RotLeft = _RotLeft;
                PTwoParty.Remove(_ActiveCharacter);
                PTwoParty.Insert(_CharacterIndex, _ActiveCharacter);
                ToggleObject(_Character, PTwoParty);
                _Character.transform.rotation = _ActiveCharacter.transform.rotation;
                _ActiveCharacter.transform.parent = BenchPTwo.transform;
                _ActiveCharacter.SetActive(false);

            }
            //    }


            //}

        }
    }
}


