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


    public Animator Animator
    {
        set { animator = value; }
    }

    public void PlayAnimation(string name)
    {
        int attackAnimation=0;
        int deathAnimation=0;

        switch (name)
        {
            case "Move":
                animationToPlay = animationsNames.Move;
                break;
            case "Attack":
                attackAnimation = Random.Range(0, 2);
                animationToPlay = animationsNames.Attack;
                break;
            case "Death":
                animationToPlay = animationsNames.Death;
                break;
            default:
                deathAnimation = Random.Range(0, 2);
                animationToPlay = animationsNames.Move;
                break;
        }

        animator.SetInteger("State", (int)animationToPlay);
        if((int)animationToPlay==1) animator.SetInteger("Attack", attackAnimation);
        if ((int)animationToPlay == 4) animator.SetInteger("Death", deathAnimation);

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
