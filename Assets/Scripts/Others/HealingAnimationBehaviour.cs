using UnityEngine;

public class HealingAnimationBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Heal Anim end");
        if (animator.GetInteger("State") != 4) animator.SetInteger("State", 0);
    }
}
