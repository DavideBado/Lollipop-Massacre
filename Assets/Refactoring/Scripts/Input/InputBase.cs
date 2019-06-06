using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBase: MonoBehaviour
{
    public KeyCode Up, Down, Left, Right, BasicAttack, Ability, Preview, Switch_Up, Switch_Down, Teleport, Select, Select2;
    private bool isAxisInUse = false;

    public virtual void CheckInput()
    {
        
    }
}
