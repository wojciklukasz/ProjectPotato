using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    private float nextAttack;
    [SerializeField] private float attackSpeed = 0.9f;
    [SerializeField] private PlayerAnimations animations;

    public float AttackSpeed
    {
        set { attackSpeed = value; }
    }

    public PlayerAnimations Animations
    {
        set { animations = value; }
    }

    public void Attack()
    {
        if(Time.time > nextAttack)
        {
            nextAttack = Time.time + attackSpeed;
            animations.PlayAnimation("Attack");
        }
    }
}