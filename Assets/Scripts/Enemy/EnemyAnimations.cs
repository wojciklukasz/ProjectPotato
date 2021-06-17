using UnityEngine;

public class EnemyAnimations : Animations
{
    public enum animationsNames
    {
        Idle,
        Move,
        Attack,
        Death
    };

    public animationsNames animationToPlay;

    public override void PlayAnimation(string name)
    {
        int attackAnimation = 0;

        switch (name)
        {
            case "Idle":
                animationToPlay = animationsNames.Idle;
                break;
            case "Move":
                animationToPlay = animationsNames.Move;
                break;
            case "Attack":
                attackAnimation = Random.Range(1, 4);
                animationToPlay = animationsNames.Attack;
                break;
            case "Death":
                animationToPlay = animationsNames.Death;
                break;
            default:
                animationToPlay = animationsNames.Idle;
                break;
        }

        animator.SetInteger("condition", (int)animationToPlay);
        if ((int)animationToPlay == 2) animator.SetInteger("attack", attackAnimation);

        //if ((int)animationToPlay == 3) animator.SetInteger("Death", deathAnimation);
    }
}
