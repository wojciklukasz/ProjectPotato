using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public enum animationsNames
    {
        Move,
        Attack,
        Heal,
        Dodge,
        Death
    };

    public animationsNames animationToPlay;
    private int attackAnimation;

    public Animator Animator
    {
        set { animator = value; }
    }

    public void PlayAnimation(string name)
    {
        switch (name)
        {
            case "Move":
                animationToPlay = animationsNames.Move;
                break;
            case "Attack":
                attackAnimation = Random.Range(0, 2);
                animationToPlay = animationsNames.Attack;
                break;
            default:
                animationToPlay = animationsNames.Move;
                break;
        }

        animator.SetInteger("State", (int)animationToPlay);
        if((int)animationToPlay==1) animator.SetInteger("Attack", attackAnimation);

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
