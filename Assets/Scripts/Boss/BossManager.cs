using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossManager : BossEntity
{
    [SerializeField] private BossAttack attack;
    [SerializeField] private BossMovement movement;
    [SerializeField] private EnemyUI enemyUI;
    [SerializeField] private HitboxCollider hitboxCollider;
    private float health = 0f;
    private bool isDeath = false;

    private bool isAttacking = false;

    private void Awake()
    {
        attackCounter = 0;
        health = bossStats.Health;
        dmg = bossStats.Dmg;
        movement.Agent = agent;
        movement.OnAttack += Attack;
        attack.AttackSpeed = bossStats.AttackSpeed;
        movement.Animations = animations;
        attack.Animations = animations;
        enemyUI.UpdateHealthBar(health, true);
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
        enemyUI.UpdateHealthBar(health, false);
        Destroy(this.gameObject, 5f);
    }

    public override void TakeDmg(float amount)
    {
        health -= amount;
        enemyUI.UpdateHealthBar(health, false);
    }
}

