using UnityEngine;

public class EnemyManager : EnemyEntity
{
    [SerializeField] protected EnemyAttack attack;
    [SerializeField] protected EnemyMovement movement;

    private bool isAttacking = false;

    private void Awake()
    {
        movement.Agent = agent;
        movement.OnAttack += Attack;
        attack.AttackSpeed = enemyStats.AttackSpeed;
        movement.Animations = animations;
        attack.Animations = animations;
    }

   
    void Update()
    {
        //print("CONDITION:" + anim.GetInteger("condition"));
        //print("ATTACK:" + anim.GetInteger("attack"));

        if(animations.GetIntegerCondition("condition") != 2)
        {
            isAttacking = false;
        }

        if(!isAttacking)
        {
            //print("ENEMY MOVE");
            Move();
        }
    }

    protected override void Move()
    {
        movement.MoveEnemy();
    }

    protected override void Attack()
    {
        attack.Attack();
    }

    protected override void Death()
    {
        //death
    }
}
