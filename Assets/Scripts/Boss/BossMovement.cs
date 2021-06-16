using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private BossAnimations animations;
    public Transform player;
    private Vector3 startingPosition;
    private Vector3 playerPosition;

    private float distance;
    private bool back;
    private NavMeshAgent agent;

    public UnityAction OnAttack;

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
        if (distance < 2.5f)
        {
            transform.LookAt(playerPosition);
            agent.isStopped = true;
            OnAttack?.Invoke(); //attack
        }
        else
        {
            agent.isStopped = false;
            transform.LookAt(playerPosition);
            animations.PlayAnimation("Move");
            agent.SetDestination(playerPosition);
        }
    }
    

}
