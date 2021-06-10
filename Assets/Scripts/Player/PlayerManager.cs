using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameplayInputHandler gameplayInputHandler;
    [SerializeField] private Vector3 rawInputMovement;
    [SerializeField] private CameraHandler cameraHandler;
    [SerializeField] private GameObject playerObject;
    public Stats playerStats;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerAttacking attacking;
    [SerializeField] private PlayerAnimations playerAnimations;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private GameObject weaponObject;
    BoxCollider weaponCollider;
    [SerializeField] private HitboxCollider hitboxCollider;
    [SerializeField] private float health;
    public UnityAction OnHealthUpdate;
    public UnityAction OnDeath; //anim event invokes this - death anim done
    public float attackCounter = 0;
    public float dmg = 10f;
    private bool isDeath = false;

    public float Health
    {
        get { return health; }
    }

    private void Awake()
    {
        dmg = playerStats.Dmg;
        Animator anim= playerObject.GetComponent<Animator>();
        playerAnimations.Animator = anim;
        weaponCollider = weaponObject.GetComponent<BoxCollider>();
        weaponCollider.enabled = false;
        movement.MoveSpeed = playerStats.MoveSpeed;
        movement.RotationSpeed = playerStats.RotationSpeed;
        movement.Animations = playerAnimations;

        attacking.Animations = playerAnimations;
        attacking.AttackSpeed = playerStats.AttackSpeed;
        gameplayInputHandler.OnAttackAction += Attack;

        hitboxCollider.OnKillCollision += Death; //play death anim + set hp to 0
        health = playerStats.Health;
        OnHealthUpdate?.Invoke();
    }

    private void Update()
    {
        if (playerAnimations.IsAnimationPlaying("attack1") || playerAnimations.IsAnimationPlaying("attack2"))
        {
            isAttacking = true;
            weaponCollider.enabled = true;
        }
        else
        {
            attackCounter = 0;
            isAttacking = false;
            weaponCollider.enabled = false;
        }

        if (!isAttacking && movement.enabled)
        {
            Movement();
        }

        if(health<=0f && !isDeath)
        {
            Death();
        }
    }

    public void UpdateRawMovement(Vector3 newRawInputMovement)
    {
        rawInputMovement = newRawInputMovement;
    }

    private void Movement()
    {
        movement.SetRawInputMovement(rawInputMovement);
        movement.MovePlayer();
    }

    private void Attack()
    {
        if (!isAttacking && attacking.enabled)
        {
            weaponCollider.enabled = true;
            attacking.Attack();
        }
    }

    private void Death()
    {
        isDeath = true;
        print("Kill player");
        attacking.enabled = false;
        movement.enabled = false;
        playerAnimations.PlayAnimation("Death");
        health = 0.0f;
        OnHealthUpdate?.Invoke();
    }

    public void TakeDmg(float amount)
    {
        if (health > 0f)
        {
            health -= amount;
            OnHealthUpdate?.Invoke();
        }
    }
}
