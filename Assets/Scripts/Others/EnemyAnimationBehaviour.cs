using UnityEngine;

public class EnemyAnimationBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("ENEMY Attack Anim end");
        animator.SetInteger("condition", 0);
        animator.SetInteger("attack", -1);
    }
}
