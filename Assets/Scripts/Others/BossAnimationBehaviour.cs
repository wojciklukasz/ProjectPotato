using UnityEngine;

public class BossAnimationBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("BOSS Attack Anim end");
        if (animator.GetInteger("State") != 3) animator.SetInteger("State", 0);
        animator.SetInteger("attack", -1);
    }
}