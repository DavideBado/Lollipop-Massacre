using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialCountDownState : StateBehaviourBase
{
    float timerIniziale;
    /// <summary>
    /// onenter attiviamo Ui del countdown iniziale
    /// disattivati input per entrambi i player
    /// settare currentPlayer
    /// </summary>
    public override void OnEnter()
    {
        timerIniziale = ctx.timer;
        //GameManager.singleton.InputMngr.ChangeInput(InputMgrType.nullo);
    }
    /// <summary>
    /// funzione del counter
    /// </summary>
    public override void OnUpdate()
    {
        timerIniziale -= Time.deltaTime;
        if (timerIniziale <= 0)

            GameManager.GoToIdle();
    }

    /// <summary>
    /// onexit, disattiviamo Ui
    /// attiva input gameplay per player di turno
    /// </summary>
    public override void OnExit()
    {

    }


}
