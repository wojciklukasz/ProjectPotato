using UnityEngine;

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

    private void Awake()
    {
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
            isAttacking = false;
            weaponCollider.enabled = false;
        }

        if (!isAttacking)
        {
            Movement();
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
        if (!isAttacking)
        {
            weaponCollider.enabled = true;
            attacking.Attack();
        }
    }
}
