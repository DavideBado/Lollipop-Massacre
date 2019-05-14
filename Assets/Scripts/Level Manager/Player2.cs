using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;
using System.Linq;

public class Player2 : Agent
{
    private void Update()
    {
        //TextUpdate();      
        InUpdate();
		TurnUpdate();

	}

	void TurnUpdate()
	{
		MyTurn = !FindObjectOfType<OldGameManager>().Turn;
	}



	//void TextUpdate()
 //   {
 //       Lifetext.text = GetComponent<LifeManager>().Life.ToString(); // Life on screen

 //   }
   
}
