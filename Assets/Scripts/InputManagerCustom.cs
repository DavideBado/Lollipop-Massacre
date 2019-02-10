using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCustom : MonoBehaviour {

    
    public KeyCode Up, Down, Left, Right, BasicAttack;
    private bool isAxisInUse = false;
    public int ManagerPlayerID;
    


    
    // Update is called once per frame
    void Update () {


        Debug.Log("GP_VerticalArrow" + ManagerPlayerID.ToString());
        GpInputCall();
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
        
    
        if (Input.GetKeyDown(BasicAttack))
        {
            SendMessage("BasicAttack");
        } 
        

       
    }

    void GpInputCall()
    {
        if (!isAxisInUse)
        {
            if (Input.GetAxisRaw("GP_VerticalArrow" + ManagerPlayerID.ToString()) == 1)
            {
                SendMessage("Up");
                isAxisInUse = true;
                
            }
            else if (Input.GetAxisRaw("GP_VerticalArrow" + ManagerPlayerID.ToString()) == -1)
            {
                SendMessage("Down");
                isAxisInUse = true;
            }
            else if (Input.GetAxisRaw("GP_HorizontalArrow" + ManagerPlayerID.ToString()) == 1)
            {
                SendMessage("Right");
                isAxisInUse = true;
            }
            else if (Input.GetAxisRaw("GP_HorizontalArrow" + ManagerPlayerID.ToString()) == -1)
            {
                SendMessage("Left");
                isAxisInUse = true;
            }
        }
        else if (Input.GetAxisRaw("GP_HorizontalArrow" + ManagerPlayerID.ToString()) == 0 && Input.GetAxisRaw("GP_VerticalArrow" + ManagerPlayerID.ToString()) == 0)
        {
            isAxisInUse = false;
        }
    }

}
