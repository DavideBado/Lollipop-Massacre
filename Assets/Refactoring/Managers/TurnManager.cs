using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public float Timer;
    float Timer2, m_TimerSafe = 0;
    public float TimeMax = 3f, TimerSafe = 0;
    public bool Turn = true, CanAttack = true, Pause = false;
    public int RoundCount = 0, PickUpTurnCount = 0, HealtTurnCount = 0;
    public bool Spawn1 = true;
    public RespawnController RespawnController;
    public bool TimerOn = true;
    float portalTimer;
    TeleportSpawner PortalSpawner;
    int PortalRounds = 0;

    void Update()
    {
        SpawnUpdate();// Controlla quando attivare lo spawn dinamico
        TimeForThePlayer();
    }

    public void SetUp()
    {
        PortalSpawner = FindObjectOfType<TeleportSpawner>();
        RespawnController = FindObjectOfType<RespawnController>();
    }

    #region API
    /// <summary>
    /// This check the time && switch the rounds
    /// </summary>
    /// TODO : Si deve attivare durante il gameplay
    void TimeForThePlayer() 
    {
        Timer2 = Mathf.Round(Timer);
        if (TimerOn == true)
        {
            Timer -= Time.deltaTime;
        }


        if (Timer <= 0) // Se il timer raggiunge lo 0
        {
            
            if (PortalRounds >= 5)
            {
                PortalSpawner.Telespawn();
                PortalRounds = 0;
            }
            if (PortalSpawner.teleports.Count == 1)
            {
                portalTimer -= Time.deltaTime;
                if (portalTimer <= 0)
                {
                    PortalSpawner.Telespawn();
                }
            }
            m_TimerSafe -= Time.deltaTime; // Attiva il tempo supplementare
            Pause = true;
            TimerOn = false;
            //m_slider.SetActive(false);
            if (m_TimerSafe <= 0) // E anche il tempo supplementare è finito
            {
                TimerOn = true;
                //m_slider.SetActive(true);
                Pause = false;
                Turn = !Turn; // Change player
                Timer = TimeMax;
                TimeMax = 5f; //Imposta nuovamente il timer
                m_TimerSafe = TimerSafe; //Imposta nuovamente il tempo supplementare
                CanAttack = true;// Il giocatore può attaccare
                PickUpTurnCount++;
                HealtTurnCount++;
                PortalRounds++;
                if (Turn == true)// Se è nuovamente il turno del primo giocatore
                {
                    RoundCount++; // Aggiorna il contatore dei round                  
                }
            }
        }
    }

    /// <summary>
    /// Setta il metodo di Spawn
    /// </summary>
    void SpawnUpdate()
    {
        if (RoundCount == 2) // Se non è più il primo round
        {
            Spawn1 = false; // Il metodo di spawn cambia
        }
    }
    #endregion
}
