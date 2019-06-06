using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : InputBase
{

    private void Update()
    {
        CheckInput();
    }
    public override void CheckInput()
    {
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

        if (Input.GetKeyDown(Select))
        {
            GameManager.singleton.InputMngr.GoToSelect();
        }

        if (Input.GetKeyDown(Select2))
        {
            GameManager.singleton.InputMngr.GoToSelect();
        }

    }
}
