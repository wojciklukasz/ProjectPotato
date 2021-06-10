using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyAnimations animations;

    private float nextAttack;
    [SerializeField] private float attackSpeed = 0.9f;

    public EnemyAnimations Animations
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
