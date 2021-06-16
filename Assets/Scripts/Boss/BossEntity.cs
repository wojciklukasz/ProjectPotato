using UnityEngine;
using UnityEngine.AI;

public abstract class BossEntity : MonoBehaviour
{
    [SerializeField] protected PlayerManager player;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected GameObject enemyObj;
    [SerializeField] protected BossAnimations animations;
    [SerializeField] public Stats bossStats;
    public float attackCounter = 0;
    public float dmg = 5f;

    protected abstract void Attack();
    protected abstract void Move();
    protected abstract void Death();
    public abstract void TakeDmg(float amount);
}
