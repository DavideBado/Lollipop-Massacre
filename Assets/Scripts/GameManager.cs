using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text Timertext, ActionsMaxText, ActionsText, TimeMaxText;
    //GameObject P1, P2;
    float Timer, Timer2;
    public float TimeMax = 3f;
    public bool Round = true;
    public int MaxAct, Actions = 5;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        GameDesignerInput(); // This is for GD, to check the best value in the build version.

        if (Input.GetKeyDown(KeyCode.Escape))// Close the game, only in the build version
        {
            Application.Quit();
        }

        TimeForThePlayer();
        Timertext.text = "Tempo:" + Timer2.ToString(); // Visualizza il tempo
        ActionsMaxText.text = "Azioni max:" + MaxAct.ToString(); // Visualizza azioni massime
        ActionsText.text = "Azioni:" + Actions.ToString(); // Visualizza azioni disponibili
        TimeMaxText.text = "Tempo massimo:" + TimeMax.ToString(); // Visualizza il tempo massimo
    }

    void TimeForThePlayer() // This check the time && switch the rounds
    {
        Timer2 = Mathf.Round(Timer);
        Timer -= Time.deltaTime;
        if ((Timer <= 0 || Actions <= 0) && Round == true)
        {
            Round = false; // Change player
            Timer = TimeMax; //Reset time
            Actions = MaxAct;// Reset actions
        } else if ((Timer <= 0 || Actions <= 0) && Round == false)
        {
            Round = true;
            Timer = TimeMax;
            Actions = MaxAct;
        }
    } 

    public void LessAct()
    {
        Actions--;
    } //Conta le azioni fatte

    public void GameDesignerInput()
    {
        // Change timemax
        #region TimeMax
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TimeMax = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TimeMax = 2f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TimeMax = 3f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TimeMax = 4f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TimeMax = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TimeMax = 6f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TimeMax = 7f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TimeMax = 8f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TimeMax = 9f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TimeMax = 10f;
        }
        #endregion
        // Change max actions
        #region Actions for round
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            MaxAct = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            MaxAct = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            MaxAct = 3;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            MaxAct = 4;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            MaxAct = 5;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            MaxAct = 6;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            MaxAct = 7;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            MaxAct = 8;
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            MaxAct = 9;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            MaxAct = 10;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            MaxAct = 10000000;
        }
        #endregion
    }
}
