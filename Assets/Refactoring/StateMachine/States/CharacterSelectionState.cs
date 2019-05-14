using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionState : StateBehaviourBase {

    public override void OnEnter()
    {
        GameManager.singleton.UIMngr.ChangeMenu(MenuType.CharacterSelection);
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        GameManager.singleton.UIMngr.CharacterSelection.SetActive(false);
    }
}
