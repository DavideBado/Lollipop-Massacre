using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreTurnState : StateBehaviourBase
{
    public float timer;
    public override void OnEnter()
    {
        GameManager.singleton.TurnMngr.ChangeTurn();
        SetPlayerID();
        SetCurrentPlayer();
        GameManager.singleton.InputMngr.ChangeInput(InputMgrType.nullo);
        timer = ctx.preturnTimer;
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            GameManager.GoToIdle();
    }

    public override void OnExit()
    {
       
    }

    public void SetCurrentPlayer()
    {
        ctx.CurrentPlayer = GameManager.singleton.PlayerMngr.PlayerID;
    }

    public void SetPlayerID()
    {
        if (GameManager.singleton.TurnMngr.Turn == true)
        {
            GameManager.singleton.PlayerMngr.PlayerID = 1;
        }
        else if (GameManager.singleton.TurnMngr.Turn == false)
        {
            GameManager.singleton.PlayerMngr.PlayerID = 2;
        }
    }
}
