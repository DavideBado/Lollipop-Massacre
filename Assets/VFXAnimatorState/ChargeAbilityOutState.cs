using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAbilityOutState : StateMachineBehaviour
{
    VFXController MyVFXController;
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MyVFXController = animator.GetComponent<VFXController>();
        MyVFXController.DeactivateVFX(MyVFXController.AbilityVFX);
    }

}
