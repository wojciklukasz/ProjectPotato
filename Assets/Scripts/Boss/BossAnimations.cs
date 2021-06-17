using UnityEngine;

public class BossAnimations : Animations
{
    public enum animationsNames
    {
        IdleAndRun,
        Attack,
        Throwing,
        Death
    };

    public animationsNames animationToPlay;

    public override void PlayAnimation(string name)
    {
        int attackAnimation = 0;

        switch (name)
        {
            case "IdleAndRun":
                animationToPlay = animationsNames.IdleAndRun;
                break;
            case "Attack":
                attackAnimation = Random.Range(0, 2);
                animationToPlay = animationsNames.Attack;
                break;
            case "Throw":
                animationToPlay = animationsNames.Throwing;
                break;
            case "Death":
                animationToPlay = animationsNames.Death;
                break;
            default:
                animationToPlay = animationsNames.IdleAndRun;
                break;
        }

        animator.SetInteger("State", (int)animationToPlay);
        if ((int)animationToPlay == 1) animator.SetInteger("attack", attackAnimation);
    }
}
