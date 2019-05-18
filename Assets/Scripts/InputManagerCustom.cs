using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCustom : MonoBehaviour {

    
    public KeyCode Up, Down, Left, Right, BasicAttack, Ability, Preview, Switch_A, Switch_B, Switch_C;
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

        if(Input.GetKeyDown(Switch_A))
        {
            SendMessage("Switch_A");
        }
        if (Input.GetKeyDown(Switch_B))
        {
            SendMessage("Switch_B");
        }
        if (Input.GetKeyDown(Switch_C))
        {
            SendMessage("Switch_C");
        }
    }
    #endregion

    #region JoystickInput
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
    #endregion

}
