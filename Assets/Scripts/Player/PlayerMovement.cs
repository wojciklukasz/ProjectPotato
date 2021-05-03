using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 rawInputMovement;
    [SerializeField] private CharacterController characterController;
    private float verticalVel;
    [SerializeField] private Vector3 moveVector;

    [SerializeField] private Camera mainCamera;
    private Vector3 desiredMoveDirection;
    [SerializeField] private bool blockRotationPlayer;
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float allowPlayerRotation;
    [SerializeField] private float moveSpeed = 20f;

    [SerializeField] private Animator playerAnimator;

    public float MoveSpeed
    {
        set { moveSpeed = value; }
    }

    public Animator PlayerAnimator
    {
        set { playerAnimator = value; }
    }

    public float RotationSpeed
    {
        set { rotationSpeed = value; }
    }

    public void SetRawInputMovement(Vector3 newRawInputMovement)
    {
        rawInputMovement = newRawInputMovement;
    }

    private void Awake()
    {
        if(!mainCamera) { mainCamera = Camera.main; }
    }

    public void MovePlayer()
    {
        CheckIsGrounded();
        MoveAndRotate();
        moveVector = new Vector3(0, verticalVel, 0);
        characterController.Move(moveVector);
    }

    private void MoveAndRotate()
    {
        float speed;
        speed = new Vector2(rawInputMovement.x, rawInputMovement.z).sqrMagnitude;

        if (speed > allowPlayerRotation)
        {
            playerAnimator.SetInteger("State", 0);
            playerAnimator.SetFloat("InputMove", speed, 0.0f, Time.deltaTime);
            var forward = mainCamera.transform.forward;
            var right = mainCamera.transform.right;
            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            desiredMoveDirection = forward * rawInputMovement.z + right * rawInputMovement.x;

            if (!blockRotationPlayer)
            {//movement
                characterController.Move(desiredMoveDirection * Time.deltaTime * moveSpeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
            }
        }
        else if (speed <= allowPlayerRotation)
        {
            playerAnimator.SetFloat("InputMove", speed, 0.0f, Time.deltaTime);
        }
    }

    private void CheckIsGrounded()
    {
        if (characterController.isGrounded) verticalVel -= 0;
        else verticalVel -= 2;
    }
}
