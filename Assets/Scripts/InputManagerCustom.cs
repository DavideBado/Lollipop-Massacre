using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCustom : MonoBehaviour {

    public KeyCode Up, Down, Left, Right;    
	
	// Update is called once per frame
	void Update () {
        InputCall(); // Questo non era strettamente necessario, ma metti che si voglia aggiungere altra roba in questo manager rende più ordinato
	}

    void InputCall() // This inputcheck can be used in a menu orndocazzovuoi
    { 
        if(Input.GetKeyDown(Up))
        {
            SendMessage("Up");
        }
        if (Input.GetKeyDown(Down))
        {
            SendMessage("Down");
        }
        if (Input.GetKeyDown(Left))
        {
            SendMessage("Left");
        }
        if (Input.GetKeyDown(Right))
        {
            SendMessage("Right");
        }
    }
}
