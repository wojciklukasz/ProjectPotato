using UnityEngine;

public class EnemyManager : EnemyEntity
{
    [SerializeField] private EnemyAnimations animations;
    [SerializeField] private EnemyAttack attack;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyUI enemyUI;
    private float health=0f;
    private bool isDeath = false;

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
        if(health<=0f && !isDeath)
        {
            Death();
        }
        else if(!isDeath)
        {
            if (animations.GetIntegerCondition("attack") == -1)
            {
                attackCounter = 0;
                isAttacking = false;
            }

            if (!isAttacking)
            {
                //print("ENEMY MOVE");
                Move();
            }
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
        isDeath = true;
        print("Kill enemy");
        animations.PlayAnimation("Death");
        attack.enabled = false;
        movement.enabled = false;
        health = 0.0f;
        enemyUI.UpdateHealthBar(health, false);
        Destroy(this.gameObject,5f);
    }

    public override void TakeDmg(float amount)
    {
        health -= amount;
        enemyUI.UpdateHealthBar(health, false);
    }
}
