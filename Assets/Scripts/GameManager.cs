using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text Timertext, TimeMaxText;
    float Timer, Timer2, TimerSafe = 0.2f;
    public float TimeMax = 3f, Speed = 25f;
    public bool Round = true, CanAttack = true;
 

    // Use this for initialization
    void Start() {

        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Escape))// Close the game, only in the build version
        {
            Application.Quit();
        }

        TimeForThePlayer();
        Timertext.text = "Tempo:" + Timer2.ToString(); // Visualizza il tempo        
        TimeMaxText.text = "Tempo massimo:" + TimeMax.ToString(); // Visualizza il tempo massimo
    }

    void TimeForThePlayer() // This check the time && switch the rounds
    {
        Timer2 = Mathf.Round(Timer);
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            TimerSafe -= Time.deltaTime;
        }
        if (Timer <= 0 && Round == true)
        {
            if (TimerSafe <= 0)
            {
                Round = false; // Change player
                Timer = TimeMax; //Reset time
                TimerSafe = 0.2f;
                CanAttack = true;
            }
        }
        else if (Timer <= 0 && Round == false)
        {
            if (TimerSafe <= 0)
            {
                Round = true;
                Timer = TimeMax;
                TimerSafe = 0.2f;
                CanAttack = true;
            }
        }
    } 
}
