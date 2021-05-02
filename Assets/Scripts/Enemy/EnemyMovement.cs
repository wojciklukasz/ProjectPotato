using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemyAttack attack;
    public Transform player;
    public Vector3 pos;
    private int speed = 3;

    private float distance;
    private float distanceFromRespawn;
    private bool Back;
    public static bool close;
    void Start()
    {
        pos = transform.position;
    }
    public Animator EnemyAnimator
    {
        set { enemyAnimator = value; }
    }
    public void GoBack()
    {
        enemyAnimator.SetInteger("condition", 1);
        transform.LookAt(pos);
        transform.position += transform.forward * speed * 1.5f * Time.deltaTime;
        distanceFromRespawn = Vector3.Distance(pos, transform.position);
        if (distanceFromRespawn < 1.0f)
        {
            enemyAnimator.SetInteger("condition", 0);
            transform.LookAt(player.transform);
            Back = false;
        }
    }
    public void MoveEnemy()
    {
        if (Back == true)
        {
            GoBack();
        }
        else if (close == true)
        {
            attack.Attack();
        }
        else {
            distance = Vector3.Distance(player.position, transform.position);
            distanceFromRespawn = Vector3.Distance(pos, transform.position);
            if (distanceFromRespawn > 30f)
            {
                Back = true;
            }
            else if (distance < 2.5f)
            {
                close = true;
                enemyAnimator.SetInteger("condition", 0);

            }
            else if (distance < 15.0f)
            {
                enemyAnimator.SetInteger("condition", 1);
                transform.LookAt(player.transform);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else if(distanceFromRespawn > 2f)
            {
                Back = true;
            }
            else
            {
                enemyAnimator.SetInteger("condition", 0);
            }
        }
        
    }
}
