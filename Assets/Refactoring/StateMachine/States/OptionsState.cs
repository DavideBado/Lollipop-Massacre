using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsState : StateBehaviourBase {

    public override void OnEnter()
    {
        
        GameManager.singleton.UIMngr.ChangeMenu(MenuType.Options);
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.singleton.UIMngr.Options.SetActive(false);
    }

}
