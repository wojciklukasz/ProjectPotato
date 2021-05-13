using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GameplayInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Vector3 rawInputMovement; //temp for testing/debugging
    [SerializeField] private Vector3 rawCameraInput; //temp for testing/debugging
    public UnityAction OnMovementAction;
    public UnityAction OnCameraMovementAction;
    public UnityAction OnAttackAction;
    public UnityAction OnDodgeAction;
    public UnityAction OnHealingAction;
    public UnityAction OnInteractionAction;
    public UnityAction OnPauseAction;

    public void OnMove(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        //print("InputMovemnt: " + inputMovement);
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        //OnMovementAction?.Invoke();
    }

    public void OnCameraMove(InputAction.CallbackContext value)
    {
        Vector2 inputCameraMovement = value.ReadValue<Vector2>();
        //print("CameraInput: " + inputCameraMovement);
        rawCameraInput = new Vector3(inputCameraMovement.x, 0, inputCameraMovement.y);
        //OnCameraMovementAction?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            OnAttackAction?.Invoke();
            print("Attack button");
        }
    }

    public void OnDodge(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            OnDodgeAction?.Invoke();
            print("Dodge button");
        }
    }

    public void OnHealing(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            OnHealingAction?.Invoke();
            print("Healing button");
        }
    }

    public void OnInteraction(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            OnInteractionAction?.Invoke();
            print("Interaction button");
        }
    }

    public void OnPause(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            OnPauseAction?.Invoke();
            print("Pause button");
        }
    }

    public Vector3 getRawInputCamera()
    {
        return rawCameraInput;
    }

    public Vector3 getRawInputMovement()
    {
        return rawInputMovement;
    }

    public void SwitchActionMapToUI()
    {
        playerInput.SwitchCurrentActionMap("UI");
    }

    public void SwitchActionMapToPlayer()
    {
        playerInput.SwitchCurrentActionMap("Player");
    }
}
