using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeep : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.BroadcastMessage("Beep");
    }
}
