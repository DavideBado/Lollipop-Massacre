using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject EventSBase, EventSPOne, EventSTwo;
    public GameObject PausePanel, EndGamePanel, POneWins, PTwoWins;
    int m_SwitchPOne, m_SwitchPTwo;
    public List<GameObject> POneParty = new List<GameObject>();
    public List<GameObject> PTwoParty = new List<GameObject>();
    public List<Transform> SpawnPoints = new List<Transform>();
    GameObject m_slider;
    public GameObject BenchPOne, BenchPTwo;
    bool state;    
    public Text Timertext, TimeMaxText, TurnoText;
    float Timer, Timer2, m_TimerSafe = 0;
    public float TimeMax = 3f, Speed = 25f, TimerSafe = 0;
    public bool Turn = true, CanAttack = true, Pause = false;
    public int RoundCount = 0, PickUpTurnCount = 0;
    public bool Spawn1 = true;
    public RespawnController RespawnController;
    public bool TimerOn = true;
    // Update is called once per frame

    private void Start()
    {
        m_SwitchPOne = 2;
        m_SwitchPTwo = 2;
        //m_slider = FindObjectOfType<CounterPosition>().gameObject;

        //UpdateBenchTester();
        UpdateBench();
        RespawnController = GetComponent<RespawnController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && Time.timeScale != 0)
        {
            EventSBase.SetActive(false);
            EventSPOne.SetActive(true);
            EventSTwo.SetActive(true);
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("In pausa");
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            EventSBase.SetActive(true);
            EventSPOne.SetActive(false);
            EventSTwo.SetActive(false);
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("Out pausa");

        }
        Debug.Log(POneParty[0].name + " è attivo:" + POneParty[0].gameObject.activeInHierarchy + "  " + POneParty[0].gameObject.activeSelf);
        Debug.Log("primo:" + POneParty[0].name + " ultimo:" + POneParty[2].name);
        InUpdate();
    }

    void InUpdate()
    {       
        TimeForThePlayer(); // Controlla il tempo e gestisce i round
        TextUpdate(); // Aggiorna i testi a schermo
        SpawnUpdate();// Controlla quando attivare lo spawn dinamico
        QuitNow(); // Chuide il gioco
        //PickUpSpawn();
    }

    #region UPDATE

    void QuitNow()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// Close the game, only in the build version
        {
            SceneManager.LoadScene(0);
            //Application.Quit();
        }
    }

    void TextUpdate()
    {
        //Timertext.text = "Tempo:" + Timer2.ToString(); // Visualizza il tempo        
        //TimeMaxText.text = "Tempo massimo:" + TimeMax.ToString(); // Visualizza il tempo massimo
        if(Turn == true)
        {
            TurnoText.text = "TURNO P1";
        } else TurnoText.text = "TURNO P2";
    }

    void TimeForThePlayer() // This check the time && switch the rounds
    {
        Timer2 = Mathf.Round(Timer);
        if(TimerOn == true)
        {
            Timer -= Time.deltaTime;
        }
        

        if (Timer <= 0) // Se il timer raggiunge lo 0
        {
            m_TimerSafe -= Time.deltaTime; // Attiva il tempo supplementare
            Pause = true;
            //m_slider.SetActive(false);
            if (m_TimerSafe <= 0) // E anche il tempo supplementare è finito
            {
                //m_slider.SetActive(true);
                Pause = false;
                Turn = !Turn; // Change player
                Timer = TimeMax; //Imposta nuovamente il timer
                m_TimerSafe = TimerSafe; //Imposta nuovamente il tempo supplementare
                CanAttack = true;// Il giocatore può attaccare
                PickUpTurnCount++;
                if (Turn == true)// Se è nuovamente il turno del primo giocatore
                {
                    RoundCount++; // Aggiorna il contatore dei round                  
                }
            }
        }
    }

    void SpawnUpdate()
    {
        if(RoundCount == 2) // Se non è più il primo round
        {
            Spawn1 = false; // Il metodo di spawn cambia
        }
    }

    void PickUpSpawn()
    {
        if(PickUpTurnCount == 3)
        {
            SendMessage("SpawnAPickUp");
            PickUpTurnCount = 0;
        }
    }
    #endregion

    public void NextPlease(PlayerData _OtherPlayer)
    {
        //Instantiate(Player, RespawnController.FindAGoodPoint(_OtherPlayer), Quaternion.identity);
    }

    void UpdateBench()
    {
        if (PartyData.POnePart != null)
        {
            int i = 1;

            foreach (GameObject _Character in PartyData.POnePart)
            {
             
                GameObject m_Character = Instantiate(_Character, SpawnPoints[0].position, Quaternion.identity, null);
                POneParty.Add(m_Character);
                m_Character.GetComponent<Agent>().SwitchIndex = i;
                i ++;
                Debug.Log(m_Character.activeSelf);

                m_Character.transform.parent = BenchPOne.transform;
                m_Character.SetActive(false);
                Debug.Log("Dopo" + m_Character.activeSelf);
            }
        }
        if (PartyData.PTwoPart != null)
        {
            int i = 1;

            foreach (GameObject _Character in PartyData.PTwoPart)
            {
                GameObject m_Character = Instantiate(_Character, SpawnPoints[1].position, Quaternion.identity, null);
                PTwoParty.Add(m_Character);
                m_Character.GetComponent<Agent>().SwitchIndex = i;
                i++;
                m_Character.transform.parent = BenchPTwo.transform;
                m_Character.SetActive(false);
            }            
        }
        ActiveStarters();
    }
    void PgInStartPosition(List<GameObject> _m_agents, int _PlayerID)
    {
        Transform _Bench = null;

        if(_PlayerID == 1)
        {
            _Bench = BenchPOne.transform;
        }
        else if(_PlayerID == 2)
        {
            _Bench = BenchPTwo.transform;
        }
        if (_m_agents.Count > 0)
        {
            
            GameObject _chara = _m_agents[0];
            _m_agents.Remove(_chara);
            _m_agents.Add(_chara);
            
            SetNewPosition(_chara, SpawnPoints[(_PlayerID -1)].position);
            ToggleObject(_chara, _Bench);
          
        }
    }

    void SetNewPosition(GameObject _agent, Vector3 _SpawnPoint)
    {
        _agent.GetComponent<Agent>().AgentParent = null;
        _agent.GetComponent<Agent>().AgentSpawnPosition = _SpawnPoint;
        _agent.GetComponent<Agent>().transform.parent = null;
        _agent.GetComponent<Agent>().transform.position = _SpawnPoint;

    }

    void ToggleObject(GameObject _go, Transform _goBench)
    {
        _goBench.GetChild(_go.transform.GetSiblingIndex()).gameObject.SetActive(true);   
    }

    void ActiveStarters()
    {
        PgInStartPosition(POneParty, 1);
        PgInStartPosition(PTwoParty, 2);
    }

    public void Switcher(int _PlayerID, int _CharacterIndex, GameObject _ActiveCharacter)
    {
        if(_PlayerID == 1 && m_SwitchPOne > 0)
        {
            // Spegnere il personaggio in scena, attivare quello selezionato e metterlo nella stessa posizione di quello appena  
            foreach (GameObject _Character in POneParty)
            {
                if(_Character.GetComponent<Agent>().SwitchIndex == _CharacterIndex)
                {
                    _Character.transform.position = _ActiveCharacter.transform.position;
                    _Character.GetComponent<Agent>().AgentSpawnPosition = _ActiveCharacter.transform.position;
                    ToggleObject(_Character, BenchPOne.transform);
                }
            }
            _ActiveCharacter.transform.parent = BenchPOne.transform;
            _ActiveCharacter.SetActive(false);
            m_SwitchPOne--;
        }
        else if(_PlayerID == 2 && m_SwitchPTwo > 0)
        {
            foreach (GameObject _Character in PTwoParty)
            {
                if (_Character.GetComponent<Agent>().SwitchIndex == _CharacterIndex)
                {
                    _Character.transform.position = _ActiveCharacter.transform.position;
                    _Character.GetComponent<Agent>().AgentSpawnPosition = _ActiveCharacter.transform.position;
                    ToggleObject(_Character, BenchPTwo.transform);
                }
            }
            _ActiveCharacter.transform.parent = BenchPTwo.transform;
            _ActiveCharacter.SetActive(false);
            m_SwitchPTwo--;
        }
       
    }

    public void EndGameCheck(int _PlayerID, GameObject _ActiveCharacter)
    {
        if(POneKO())
        {
            EventSBase.SetActive(false);
            EventSPOne.SetActive(true);
            EventSTwo.SetActive(true);
            EndGamePanel.SetActive(true);
            POneWins.SetActive(true);
            PTwoWins.SetActive(false);
            Debug.Log("P2 Ha vinto");
        }
        else if (PTwoKO())
        {
            EventSBase.SetActive(false);
            EventSPOne.SetActive(true);
            EventSTwo.SetActive(true);
            EndGamePanel.SetActive(true);
            POneWins.SetActive(false);
            PTwoWins.SetActive(true);
            Debug.Log("P1 Ha vinto");
        }
        else
        {
            if (_PlayerID == 1)
            {
                ChangePg(POneParty, _PlayerID);
            }
            else if(_PlayerID == 2)
            {
                ChangePg(PTwoParty, _PlayerID);
            }
            _ActiveCharacter.SetActive(false);
        }
    }

    bool POneKO()
    {
        if(POneParty[0].GetComponent<LifeManager>().Life == 0)
        {
            if (POneParty[1].GetComponent<LifeManager>().Life == 0)
            {
                if (POneParty[2].GetComponent<LifeManager>().Life == 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }

    bool PTwoKO()
    {
        if (PTwoParty[0].GetComponent<LifeManager>().Life == 0)
        {
            if (PTwoParty[1].GetComponent<LifeManager>().Life == 0)
            {
                if (PTwoParty[2].GetComponent<LifeManager>().Life == 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }

    PlayerData FindPlayer(int _PlayerID)
    {
        List<Agent> m_agents = FindObjectsOfType<Agent>().ToList();
        foreach (Agent _Player in m_agents)
        {
            if (_Player.PlayerID == _PlayerID)
            {
                return _Player.GetComponent<PlayerData>();
            }            
        }
        return null;
    }

    void ChangePg(List<GameObject> _m_agents, int _PlayerID)
    {
        Transform _Bench = null;
        int m_ActivePlayerID = 0;
        if (_PlayerID == 1)
        {
            _Bench = BenchPOne.transform;
            m_ActivePlayerID = 2;
        }
        else if (_PlayerID == 2)
        {
            _Bench = BenchPTwo.transform;
            m_ActivePlayerID = 1;
        }
        if (_m_agents.Count > 0)
        {

            GameObject _chara = _m_agents[0];
            _m_agents.Remove(_chara);
            _m_agents.Add(_chara);

            SetNewPosition(_chara,RespawnController.FindAGoodPoint(FindPlayer(m_ActivePlayerID)));
            ToggleObject(_chara, _Bench);

        }
    }

    ///////////////////////////////////////////////////////////
//    void UpdateBenchTester()
//    {
//        if (POneParty != null)
//        {
//            int i = 1;

//            foreach (GameObject _Character in POneParty)
//            {
             
//                GameObject m_Character = Instantiate(_Character);
//    //POneParty.Add(m_Character);
//                m_Character.GetComponent<Agent>().SwitchIndex = i;
//                i ++;
//                m_Character.transform.parent = BenchPOne.transform;
//                m_Character.SetActive(false);
//            }
//        }
//        if (PTwoParty != null)
//        {
//            int i = 1;

//            foreach (GameObject _Character in PTwoParty)
//            {
//                GameObject m_Character = Instantiate(_Character);
////PTwoParty.Add(m_Character);
//                m_Character.GetComponent<Agent>().SwitchIndex = i;
//                i++;
//                m_Character.transform.parent = BenchPTwo.transform;
//                m_Character.SetActive(false);
//            }            
//        }
//        ActiveStarters();
//    }

}
