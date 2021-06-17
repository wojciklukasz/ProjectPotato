using UnityEngine;

public class AttackAnimationBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Attack Anim end");
        if(animator.GetInteger("State") != 4) animator.SetInteger("State", 0);
        animator.SetInteger("Attack", -1);
    }
}
