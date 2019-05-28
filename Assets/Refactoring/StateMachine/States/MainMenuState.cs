using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : StateBehaviourBase {

    

    public override void OnEnter()
    {
        Debug.Log("MainMenuState: Enter");
        GameManager.singleton.UIMngr.ChangeMenu(MenuType.MainMenu);
        GameManager.singleton.InputMngr.ChangeInput(InputMgrType.nullo);
    }

    public override void OnUpdate()
    {
        Debug.Log("MainMenuState: Update");
        

    }

    public override void OnExit()
    {
        Debug.Log("MainMenuState: Exit");
        GameManager.singleton.UIMngr.MainMenu.SetActive(false);
    }


}
