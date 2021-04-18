using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameplayInputHandler gameplayInputHandler;
    [SerializeField] private Vector3 rawInputMovement;
    [SerializeField] private CameraHandler cameraHandler;
    [SerializeField] private GameObject playerObject;
    public Stats playerStats;
    [SerializeField] private PlayersMovement movement;

    private void Awake()
    {
        movement.PlayerAnimator = playerObject.GetComponent<Animator>();
        movement.MoveSpeed = playerStats.MoveSpeed;
        movement.RotationSpeed = playerStats.RotationSpeed;
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
}
