using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UomoDeiTurni : MonoBehaviour {
    public Text Timertext;
    GameObject P1, P2;
    float Timer = 5f, Timer2;
    bool Turno = true;
    PositionTester p1Turn;
    PositionTester1 p2Turn;
    // Use this for initialization
    void Start () {
        P1 = GameObject.Find("PositionTester");
        P2 = GameObject.Find("PositionTester2");
        p1Turn = P1.GetComponent<PositionTester>();
        p2Turn = P2.GetComponent<PositionTester1>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Tempo();
        Timertext.text = "Tempo:" + Timer2.ToString();
		if(Turno == true)
        {
            p1Turn.CheckInput();            
        } else if(Turno == false)
        {
            p2Turn.CheckInput();
        }
	}

    void Tempo()
    {
        Timer2 = Mathf.Round(Timer);
        Timer -= Time.deltaTime;
        if(Timer <= 0 && Turno == true)
        {
            Turno = false;
            Timer = 5f;
        } else if (Timer <= 0 && Turno == false)
        {
            Turno = true;
            Timer = 5f;
        }
    }
}
