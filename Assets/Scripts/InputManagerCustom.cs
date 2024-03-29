﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCustom : MonoBehaviour {

    
    public KeyCode Up, Down, Left, Right, BasicAttack, Ability, Preview, Switch_Up, Switch_Down, Teleport;
    private bool isAxisInUse = false;
    public int ManagerPlayerID;
    
    // Update is called once per frame
    void Update () {
        //GpInputCall(); // Input per joystick, momentaneamente offline
        InputCall(); 
	}

    #region KeyboardInput
    void InputCall() // This inputcheck can be used in a menu orndocazzovuoi
    { 
        if(Input.GetKey(Up))
        {
            SendMessage("Up");
            
        } 
       
        if (Input.GetKey(Down))
        {
            SendMessage("Down");
        }
        
    
        if (Input.GetKey(Left))
        {
            SendMessage("Left");
        }
        

        if (Input.GetKey(Right))
        {
            SendMessage("Right");
        }
        
    
        if (Input.GetKeyDown(BasicAttack))
        {
            SendMessage("BasicAttack");
        } 

        if(Input.GetKeyDown(Ability))
        {
            SendMessage("Ability");
        }

        if (Input.GetKey(Preview))
        {
            SendMessage("Preview");
        }else if(Input.GetKeyUp(Preview))
        {
            SendMessage("CleanPreview");
        }

        if(Input.GetKeyDown(Switch_Up))
        {
            SendMessage("Switch_Up");
        }
        if (Input.GetKeyDown(Switch_Down))
        {
            SendMessage("Switch_Down");
        }        
        if (Input.GetKeyDown(Teleport))
        {
            SendMessage("TeleportMe");
        }        
    }
    #endregion

    //#region JoystickInput
    //void GpInputCall()
    //{
    //    if (!isAxisInUse)
    //    {
    //        if (Input.GetAxisRaw("GP_VerticalArrow" + ManagerPlayerID.ToString()) == 1)
    //        {
    //            SendMessage("Up");
    //            isAxisInUse = true;
                
    //        }
    //        else if (Input.GetAxisRaw("GP_VerticalArrow" + ManagerPlayerID.ToString()) == -1)
    //        {
    //            SendMessage("Down");
    //            isAxisInUse = true;
    //        }
    //        else if (Input.GetAxisRaw("GP_HorizontalArrow" + ManagerPlayerID.ToString()) == 1)
    //        {
    //            SendMessage("Right");
    //            isAxisInUse = true;
    //        }
    //        else if (Input.GetAxisRaw("GP_HorizontalArrow" + ManagerPlayerID.ToString()) == -1)
    //        {
    //            SendMessage("Left");
    //            isAxisInUse = true;
    //        }
    //    }
    //    else if (Input.GetAxisRaw("GP_HorizontalArrow" + ManagerPlayerID.ToString()) == 0 && Input.GetAxisRaw("GP_VerticalArrow" + ManagerPlayerID.ToString()) == 0)
    //    {
    //        isAxisInUse = false;
    //    }
    //}
    //#endregion

}
