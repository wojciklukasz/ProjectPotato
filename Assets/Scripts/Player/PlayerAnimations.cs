using UnityEngine;

public class PlayerAnimations : Animations
{
    public enum animationsNames
    {
        Move,
        Attack,
        Heal,
        Dodge,
        Death
    };

    public animationsNames animationToPlay;

    public override void PlayAnimation(string name)
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
                deathAnimation = Random.Range(0, 2);
                animationToPlay = animationsNames.Death;
                break;
            default:
                //deathAnimation = Random.Range(0, 2);
                animationToPlay = animationsNames.Move;
                break;
        }

        animator.SetInteger("State", (int)animationToPlay);
        if((int)animationToPlay==1) animator.SetInteger("Attack", attackAnimation);
        if ((int)animationToPlay == 4) animator.SetInteger("Death", deathAnimation);

    }
}
