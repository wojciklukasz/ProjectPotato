using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private BossAnimations animations;
    public Transform player;
    private Vector3 playerPosition;

    private float distance;
    private NavMeshAgent agent;

    public UnityAction OnAttack;

    public bool isStartedBattle = false;

    public NavMeshAgent Agent
    {
        set { agent = value; }
    }

    public BossAnimations Animations
    {
        set { animations = value; }
    }


    public void MoveBoss()
    {
        distance = Vector3.Distance(player.position, transform.position);
        playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        if (distance < 10f)
        {
            //print("BOSS ATTACK");
            transform.LookAt(playerPosition);
            agent.isStopped = true;
            OnAttack?.Invoke(); //attack
        }
        else if (distance < 20.0f || isStartedBattle)
        {
            agent.isStopped = false;
            transform.LookAt(playerPosition);
            animations.PlayAnimation("IdleAndRun");
            agent.SetDestination(playerPosition);
        }
    }
    

}
