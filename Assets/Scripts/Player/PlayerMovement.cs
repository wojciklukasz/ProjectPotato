using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 rawInputMovement;
    [SerializeField] private CharacterController characterController;
    private float verticalVel;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private bool blockRotationPlayer;
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float allowPlayerRotation;
    [SerializeField] private float moveSpeed = 20f;

    [SerializeField] private PlayerAnimations animations;

    public float MoveSpeed
    {
        set { moveSpeed = value; }
    }

    public float RotationSpeed
    {
        set { rotationSpeed = value; }
    }

    public PlayerAnimations Animations
    {
        set { animations = value; }
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
        Vector3 moveVector = new Vector3(0, verticalVel, 0);
        characterController.Move(moveVector);
    }

    private void MoveAndRotate()
    {
        float speed;
        speed = new Vector2(rawInputMovement.x, rawInputMovement.z).sqrMagnitude;

        if (speed > allowPlayerRotation)
        {
            //animations.PlayAnimation("Move");
            animations.SetFloatAnimation("InputMove", speed);
            var forward = mainCamera.transform.forward;
            var right = mainCamera.transform.right;
            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();
            Vector3 desiredMoveDirection;
            desiredMoveDirection = forward * rawInputMovement.z + right * rawInputMovement.x;

            if (!blockRotationPlayer)
            {//movement
                characterController.Move(desiredMoveDirection * Time.deltaTime * moveSpeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
            }
        }
        else if (speed <= allowPlayerRotation)
        {
            animations.SetFloatAnimation("InputMove", speed);
        }
    }

    private void CheckIsGrounded()
    {
        if (characterController.isGrounded) verticalVel -= 0;
        else verticalVel -= 2;
    }
}
