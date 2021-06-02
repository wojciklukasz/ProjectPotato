using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyAttack attack;
    private Animator anim;

    [SerializeField] private float attackSpeed = 0.1f;



    private void Awake()
    {
        anim = enemyObject.GetComponent<Animator>();
        movement.EnemyAnimator = anim;
        attack.EnemyAnimator = anim;
    }

   
    void Update()
    {
        //print("CONDITION:" + anim.GetInteger("condition"));
        //print("ATTACK:" + anim.GetInteger("attack"));

        if (anim.GetInteger("condition") != 2)
        {
            attack.Close = false;
        }

        if (attack.Close == false)
        {
            //print("ENEMY MOVE");
            movement.MoveEnemy();
        }


    }



    private void Attack()
    {
        attack.Attack();
    }
}
