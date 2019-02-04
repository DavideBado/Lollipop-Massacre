using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text Timertext;
    GameObject P1, P2;
    float Timer, Timer2;
    public float TimeMax = 3f;
    bool Round = true;
    PositionTester p1Turn;
    PositionTester1 p2Turn;
    // Use this for initialization
    void Start () {
        P1 = GameObject.Find("PositionTester"); // Load the player
        P2 = GameObject.Find("PositionTester2");
        p1Turn = P1.GetComponent<PositionTester>();
        p2Turn = P2.GetComponent<PositionTester1>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // Close the game, only in the build version
        {
            Application.Quit();
        }

        TimeForThePlayer();
        Timertext.text = "Tempo:" + Timer2.ToString();

        if (Round == true)
        {
            p1Turn.CheckInput();            
        } else if(Round == false)
        {
            p2Turn.CheckInput();
        }
	}

    void TimeForThePlayer() // This check the time && switch the rounds
    {
        Timer2 = Mathf.Round(Timer);
        Timer -= Time.deltaTime;
        if(Timer <= 0 && Round == true)
        {
            Round = false;
            Timer = TimeMax;
        } else if (Timer <= 0 && Round == false)
        {
            Round = true;
            Timer = TimeMax;
        }
    }
}
