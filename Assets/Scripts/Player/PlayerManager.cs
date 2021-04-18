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

    private void Awake()
    {
        Animator anim= playerObject.GetComponent<Animator>();
        movement.PlayerAnimator = anim;
        movement.MoveSpeed = playerStats.MoveSpeed;
        movement.RotationSpeed = playerStats.RotationSpeed;

        attacking.PlayerAnimator = anim;
        attacking.AttackSpeed = playerStats.AttackSpeed;
        gameplayInputHandler.OnAttackAction += Attack;
    }

    private void Update()
    {
        movement.SetRawInputMovement(rawInputMovement);
        movement.MovePlayer();
    }

    public void UpdateRawMovement(Vector3 newRawInputMovement)
    {
        rawInputMovement = newRawInputMovement;
    }

    private void Attack()
    {
        attacking.Attack();
    }
}
