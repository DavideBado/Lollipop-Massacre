using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        //m_slider = FindObjectOfType<CounterPosition>().gameObject;
        UpdateBench();
        RespawnController = GetComponent<RespawnController>();
    }

    void Update()
    {
        Debug.Log(PartyData.POnePart[0].name + " è attivo:" + PartyData.POnePart[0].gameObject.activeInHierarchy + "  " + PartyData.POnePart[0].gameObject.activeSelf);
        Debug.Log("primo:" + PartyData.POnePart[0].name + " ultimo:" + PartyData.POnePart[2].name);
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
        Timertext.text = "Tempo:" + Timer2.ToString(); // Visualizza il tempo        
        TimeMaxText.text = "Tempo massimo:" + TimeMax.ToString(); // Visualizza il tempo massimo
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

    public void NextPlease(GameObject Player, PlayerData _OtherPlayer)
    {if(Player.GetComponentInChildren<Poison>() != null)
        {
            Player.GetComponentInChildren<Poison>().MaxRounds = 0;
        }
        Instantiate(Player, RespawnController.FindAGoodPoint(_OtherPlayer), Quaternion.identity);
    }

    void UpdateBench()
    {
        if (PartyData.POnePart != null)
        {
            foreach (GameObject agent in PartyData.POnePart)
            {
                GameObject Character = Instantiate(agent);
                Character.transform.parent = BenchPOne.transform;
                Character.SetActive(false);
            }
        }
        if (PartyData.PTwoPart != null)
        {
            foreach (GameObject _Character in PartyData.PTwoPart)
            {
                GameObject m_Character = Instantiate(_Character);
                m_Character.transform.parent = BenchPTwo.transform;
                m_Character.SetActive(false);
            }            
        }
        ActiveStarters();
    }
    void ChangePg(List<GameObject> _m_agents, int _SpawnPointIndex)
    {
        Transform _Bench = null;

        if(_SpawnPointIndex == 0)
        {
            _Bench = BenchPOne.transform;
        }
        else if(_SpawnPointIndex == 1)
        {
            _Bench = BenchPTwo.transform;
        }
        if (_m_agents.Count > 0)
        {
            
            GameObject _chara = _m_agents[0];
            _m_agents.Remove(_chara);
            _m_agents.Add(_chara);
            ToggleObject(_chara, _Bench);
            SetNewPosition(_chara, _SpawnPointIndex);
            //_chara.GetComponent<LifeManager>().Life -= 2;
        }
    }

    void SetNewPosition(GameObject _agent, int _SpawnPointIndex)
    {
        _agent.transform.position = SpawnPoints[_SpawnPointIndex].position;
    }

    void ToggleObject(GameObject _go, Transform _goBench)
    {
        _goBench.GetChild(_go.transform.GetSiblingIndex()).gameObject.SetActive(true);
        
        _go.SetActive(true);
        Debug.Log(_go.name);

    }

    void ActiveStarters()
    {
        ChangePg(PartyData.POnePart, 0);
        ChangePg(PartyData.PTwoPart, 1);
    }
}
