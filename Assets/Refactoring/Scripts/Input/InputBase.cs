using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBase: MonoBehaviour
{
    public KeyCode Up, Down, Left, Right, BasicAttack, Ability, Preview, Switch_Up, Switch_Down, Teleport;
    private bool isAxisInUse = false;
    


    public virtual void CheckInput()
    {
        if (Input.GetKey(Up))
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

        if (Input.GetKeyDown(Ability))
        {
            SendMessage("Ability");
        }

        if (Input.GetKey(Preview))
        {
            SendMessage("Preview");
        }
        else if (Input.GetKeyUp(Preview))
        {
            SendMessage("CleanPreview");
        }

        if (Input.GetKeyDown(Switch_Up))
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
}
