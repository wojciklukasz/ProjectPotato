using UnityEngine;

public abstract class Animations : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    public Animator Animator
    {
        set { animator = value; }
    }

    public abstract void PlayAnimation(string name);


    public int GetIntegerCondition(string conditionName)
    {
        return animator.GetInteger(conditionName);
    }

    public void SetFloatAnimation(string paramName, float speed)
    {
        animator.SetFloat(paramName, speed, 0.0f, Time.deltaTime);
    }

    public bool IsAnimationPlaying(string animName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animName)) return true;
        else return false;
    }
}
