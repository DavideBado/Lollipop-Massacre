using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : StateMachineBehaviour
{
    VFXController MyVFXController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        MyVFXController = animator.GetComponent<VFXController>();
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MyVFXController.DeactivateVFX(MyVFXController.BloodVFX);
    }
}
