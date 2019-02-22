using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Timertext, TimeMaxText, TurnoText;
    float Timer, Timer2, TimerSafe = 0.2f;
    public float TimeMax = 3f, Speed = 25f;
    public bool Round = true, CanAttack = true;
    public int RoundCount = 0;
    public bool Spawn1 = true;
    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }
    void InUpdate()
    {
        TimeForThePlayer(); // Controlla il tempo e gestisce i round
        TextUpdate(); // Aggiorna i testi a schermo
        SpawnUpdate();// Controlla quando attivare lo spawn dinamico
        QuitNow(); // Chuide il gioco
    }

    #region UPDATE

    void QuitNow()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// Close the game, only in the build version
        {
            Application.Quit();
        }
    }

    void TextUpdate()
    {
        Timertext.text = "Tempo:" + Timer2.ToString(); // Visualizza il tempo        
        TimeMaxText.text = "Tempo massimo:" + TimeMax.ToString(); // Visualizza il tempo massimo
        if(Round == true)
        {
            TurnoText.text = "TURNO P1";
        } else TurnoText.text = "TURNO P2";
    }

    void TimeForThePlayer() // This check the time && switch the rounds
    {
        Timer2 = Mathf.Round(Timer);
        Timer -= Time.deltaTime;
        if (Timer <= 0) // Se è finito il round
        {
            TimerSafe -= Time.deltaTime; // Attiva il tempo supplementare
        }
        if (Timer <= 0) // Se il timer raggiunge lo 0
        {
            if (TimerSafe <= 0) // E anche il tempo supplementare è finito
            {
                Round = !Round; // Change player
                Timer = TimeMax; //Imposta nuovamente il timer
                TimerSafe = 0.2f; //Imposta nuovamente il tempo supplementare
                CanAttack = true;// Il giocatore può attaccare
                if (Round == true)// Se è nuovamente il turno del primo giocatore
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
    #endregion

    public void NextPlease(GameObject Player)
    {
        Instantiate(Player);
    }

}
