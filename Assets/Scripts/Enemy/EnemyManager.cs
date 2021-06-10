using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : EnemyEntity
{
    [SerializeField] private EnemyAttack attack;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyUI enemyUI;
    [SerializeField] private HitboxCollider hitboxCollider;
    private float health=0f;

    private bool isAttacking = false;

    private void Awake()
    {
        attackCounter = 0;
        health = enemyStats.Health;
        dmg = enemyStats.Dmg;
        movement.Agent = agent;
        movement.OnAttack += Attack;
        attack.AttackSpeed = enemyStats.AttackSpeed;
        movement.Animations = animations;
        attack.Animations = animations;
        enemyUI.UpdateHealthBar(health, true);
    }

   
    void Update()
    {
        //print(attackCounter);
        //print("CONDITION:" + anim.GetInteger("condition"));
        //print("ATTACK:" + anim.GetInteger("attack"));

        if(animations.GetIntegerCondition("condition") != 2)
        {
            attackCounter = 0;
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

    public override void TakeDmg(float amount)
    {
        health -= amount;
        enemyUI.UpdateHealthBar(health, false);
    }
}
