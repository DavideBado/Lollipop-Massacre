using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreTurnState : StateMachineBehaviour
{
    int CurrentPlayerID;
    float TimerTest;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentPlayerID = animator.GetComponent<ContextMono>().CurrentPlayerID;
     if (CurrentPlayerID == 1)
        {
            animator.GetComponent<ContextMono>().CurrentPlayerID = 2;
        }
        else if (CurrentPlayerID == 2)
        {
            animator.GetComponent<ContextMono>().CurrentPlayerID = 1;
        }
		else if (CurrentPlayerID == 0)
        {
            animator.GetComponent<ContextMono>().CurrentPlayerID = 1;
        }
        animator.ResetTrigger("StartPreTurn");
        Debug.LogError("Enter_PreTurnState");
        TimerTest = 3f;
        animator.GetComponent<ContextMono>().StateName.text = "PreTurnState";        
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Update_PreTurnState");
        TimerTest -= Time.deltaTime;
        animator.GetComponent<ContextMono>().Info.text = "NextPlayerID:" + CurrentPlayerID + "\n" + ((int)TimerTest).ToString();
        if (TimerTest <= 0)
        {
            animator.SetTrigger("StartTurn");
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.LogError("Exit_TurnState");
        animator.GetComponent<ContextMono>().TurnTimer = 5f;
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
