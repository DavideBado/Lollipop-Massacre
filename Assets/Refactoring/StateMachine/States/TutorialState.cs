using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialState : StateBehaviourBase {

    public override void OnEnter()
    {
        GameManager.singleton.UIMngr.ChangeMenu(MenuType.Tutorial);
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.singleton.UIMngr.Tutorial.SetActive(false);
    }

}
