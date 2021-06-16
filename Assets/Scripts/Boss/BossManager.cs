using UnityEngine;
using UnityEngine.Events;

public class BossManager : EnemyEntity
{
    [SerializeField] private BossAnimations animations;
    [SerializeField] private BossAttack attack;
    [SerializeField] private BossMovement movement;
    [SerializeField] private BossUI bossUI;
    [SerializeField] private float health = 0f;
    private bool isDeath = false;

    private bool isAttacking = false;

    public UnityAction OnStartBattle;
    public UnityAction OnDeath;

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
        OnStartBattle += StartBattle;
        bossUI.DisableHPBar();
    }


    void Update()
    {
        if (health <= 0f && !isDeath)
        {
            Death();
        }
        else if (!isDeath)
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

    private void StartBattle()
    {
        bossUI.UpdateHealthBar(health, true);
        bossUI.EnableHPBar();
        movement.isStartedBattle = true;
    }

    protected override void Move()
    {
        movement.MoveBoss();
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
        bossUI.UpdateHealthBar(health, false);
        OnDeath?.Invoke();
        Destroy(this.gameObject, 5f);
        bossUI.DisableHPBar();
    }

    public override void TakeDmg(float amount)
    {
        health -= amount;
        bossUI.UpdateHealthBar(health, false);
    }
}

