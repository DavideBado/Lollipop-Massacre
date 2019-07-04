using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAbilityLoopState : StateMachineBehaviour
{

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        RaycastHit hit;
        if (Physics.Raycast(animator.GetComponentInParent<Agent>().RayCenter + new Vector3(0, 0.5f), animator.GetComponentInParent<Agent>().SavedlookAt, out hit, 1f))
        {
            animator.SetTrigger("AnimAbility");
        }
    }

}
