using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCustom : MonoBehaviour {

    
    public KeyCode Up, Down, Left, Right, BasicAttack, Attack2;
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
        
    
        if (Input.GetKey(BasicAttack))
        {
            SendMessage("BasicAttack");
        } 

        if(Input.GetKeyDown(Attack2))
        {
            SendMessage("Attack2");
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
