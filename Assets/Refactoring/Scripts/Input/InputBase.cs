using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBase: MonoBehaviour
{
    public KeyCode Up, Down, Left, Right, BasicAttack, Ability, Preview, Switch_Up, Switch_Down, Teleport;
    private bool isAxisInUse = false;
    public InputManager InputMngr;
    private void Update()
    {
        CheckInput();
    }


    public virtual void CheckInput()
    {
        if (Input.GetKey(Up))
        {
           // SendMessage("Up");
            InputMngr.GoToUp();
        }

        if (Input.GetKey(Down))
        {
            //SendMessage("Down");
            InputMngr.GoToDown();
        }


        if (Input.GetKey(Left))
        {
            //SendMessage("Left");
            InputMngr.GoToLeft();
        }


        if (Input.GetKey(Right))
        {
            //SendMessage("Right");
            InputMngr.GoToRight();
        }


        if (Input.GetKeyDown(BasicAttack))
        {
            //SendMessage("BasicAttack");
            InputMngr.GoToAttaccoBase();
        }

        if (Input.GetKeyDown(Ability))
        {
            // SendMessage("Ability");
            InputMngr.GoToAbilita();
        }

        if (Input.GetKey(Preview))
        {
            //SendMessage("Preview");
            //InputMngr.GoToPreview();
        }
        else if (Input.GetKeyUp(Preview))
        {
            //SendMessage("CleanPreview");
            
        }

        if (Input.GetKeyDown(Switch_Up))
        {
            //SendMessage("Switch_Up");
            InputMngr.GoToSwitchUp();
        }

        if (Input.GetKeyDown(Switch_Down))
        {
            // SendMessage("Switch_Down");
            InputMngr.GoToSwitchDown();
        }

        if (Input.GetKeyDown(Teleport))
        {
            //SendMessage("TeleportMe");
            InputMngr.GoToTeleport();
        }
    }
}
