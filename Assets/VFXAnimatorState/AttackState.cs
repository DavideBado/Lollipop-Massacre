using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    VFXController MyVFXController;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MyVFXController = animator.GetComponent<VFXController>();
        MyVFXController.ActiveVFX(MyVFXController.BaseAttackVFX);
    }
   
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MyVFXController.DeactivateVFX(MyVFXController.BaseAttackVFX);
    }
}
