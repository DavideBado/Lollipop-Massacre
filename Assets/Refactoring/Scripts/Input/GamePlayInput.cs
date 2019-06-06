using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayInput : InputBase
{
    public int InputID;

    private void Update()
    {
        CheckInput();
    }

    public override void CheckInput()
    {
        if(GameManager.singleton.InputMngr == null)
        {
            return;
        }

        if (Input.GetKey(Up))
        {
            // SendMessage("Up");
            GameManager.singleton.InputMngr.GoToUp();
        }

        if (Input.GetKey(Down))
        {
            //SendMessage("Down");
            GameManager.singleton.InputMngr.GoToDown();
        }


        if (Input.GetKey(Left))
        {
            //SendMessage("Left");
            GameManager.singleton.InputMngr.GoToLeft();
        }


        if (Input.GetKey(Right))
        {
            //SendMessage("Right");
            GameManager.singleton.InputMngr.GoToRight();
        }


        if (Input.GetKeyDown(BasicAttack))
        {
            //SendMessage("BasicAttack");
            GameManager.singleton.InputMngr.GoToAttaccoBase();
        }

        if (Input.GetKeyDown(Ability))
        {
            // SendMessage("Ability");
            GameManager.singleton.InputMngr.GoToAbilita();
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
            GameManager.singleton.InputMngr.GoToSwitchUp();
        }

        if (Input.GetKeyDown(Switch_Down))
        {
            // SendMessage("Switch_Down");
            GameManager.singleton.InputMngr.GoToSwitchDown();
        }

        if (Input.GetKeyDown(Teleport))
        {
            //SendMessage("TeleportMe");
            GameManager.singleton.InputMngr.GoToTeleport();
        }
    }

}
