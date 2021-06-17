
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private BossAnimations animations;
    private float nextAttack;
    [SerializeField] private float attackSpeed = 1.3f;

    public BossAnimations Animations
    {
        set { animations = value; }
    }
    public float AttackSpeed
    {
        set { attackSpeed = value; }
    }

    public void Attack()
    {
        if (Time.time > nextAttack)
        {
            //print("ENEMY ATTACK");
            nextAttack = Time.time + attackSpeed;
            //attack
            animations.PlayAnimation("Attack");
        }
    }
}