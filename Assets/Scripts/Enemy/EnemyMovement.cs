using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    public Transform player;
    public Vector3 pos;
    private int speed = 3;

    private float distance;
    private float distanceFromRespawn;
    private bool TooFar;
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
            TooFar = false;
        }
    }
    public void MoveEnemy()
    {   
        if(TooFar == true)
        {
            GoBack();
        }
        else {
            distance = Vector3.Distance(player.position, transform.position);
            distanceFromRespawn = Vector3.Distance(pos, transform.position);
            if (distanceFromRespawn > 15f)
            {
                TooFar = true;
            }
            else if (distance < 2.5f)
            {
                        enemyAnimator.SetInteger("condition", 0);
            }
            else if (distance < 10.0f)
            {
                        enemyAnimator.SetInteger("condition", 1);
                        transform.LookAt(player.transform);
                        transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        
    }
}
