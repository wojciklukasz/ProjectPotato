using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyEntity : MonoBehaviour
{
    [SerializeField] protected PlayerManager player;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected GameObject enemyObj;
    [SerializeField] protected EnemyAnimations animations;
    [SerializeField] public Stats enemyStats;

    protected abstract void Attack();
    protected abstract void Move();
    protected abstract void Death();
}
