using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyAnimations animations;
    public Transform player;
    private Vector3 startingPosition;
    private Vector3 playerPosition;

    private float distance;
    private float distanceFromRespawn;
    private bool back;
    private NavMeshAgent agent;

    public UnityAction OnAttack;

    public NavMeshAgent Agent
    {
        set { agent = value; }
    }

    private void Start()
    {
        startingPosition = transform.position;
    }

    public EnemyAnimations Animations
    {
        set { animations = value; }
    }
    
    public void GoBack()
    {
        animations.PlayAnimation("Move");
        transform.LookAt(startingPosition);
        agent.SetDestination(startingPosition);
        distanceFromRespawn = Vector3.Distance(startingPosition, transform.position);
        if (distanceFromRespawn < 1.0f)
        {
            animations.PlayAnimation("Idle");
            transform.LookAt(player.transform);
            back = false;
        }
    }

    public void MoveEnemy()
    {
        if (back == true)
        {
            agent.isStopped = false;
            GoBack();
        }
        else
        {
            distance = Vector3.Distance(player.position, transform.position);
            distanceFromRespawn = Vector3.Distance(startingPosition, transform.position);
            playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            if (distanceFromRespawn > 30f)
            {
                back = true;
                //agent.isStopped = false;
            }
            else if (distance < 2.5f)
            {
                transform.LookAt(playerPosition);
                agent.isStopped = true;
                OnAttack?.Invoke(); //attack
            }
            else if (distance < 15.0f)
            {
                agent.isStopped = false;
                transform.LookAt(playerPosition);
                animations.PlayAnimation("Move");
                agent.SetDestination(playerPosition);
            }
            else if (distanceFromRespawn > 2f)
            {
                back = true;
                //agent.isStopped = false;
            }
            else
            {
                animations.PlayAnimation("Idle");
            }
        }
    }

}
