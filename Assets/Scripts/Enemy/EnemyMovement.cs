using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemyAttack attack;
    public Transform player;
    private Vector3 pos;
    private Vector3 playerPosition;
    private int speed = 3;
    private float distance;
    private float distanceFromRespawn;
    private bool Back;
    
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
        transform.position += transform.forward * speed * 3f * Time.deltaTime;
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
        else
        {
            distance = Vector3.Distance(player.position, transform.position);
            distanceFromRespawn = Vector3.Distance(pos, transform.position);
            playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            if (distanceFromRespawn > 30f)
            {
                Back = true;
            }
            else if (distance < 2.5f)
            {
                transform.LookAt(playerPosition);
                StartCoroutine(attack.Attack());
            }
            else if (distance < 15.0f)
            {
                transform.LookAt(playerPosition);
                enemyAnimator.SetInteger("condition", 1);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else if (distanceFromRespawn > 2f)
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
