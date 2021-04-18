using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 rawInputCameraMovement;
    [SerializeField] private GameplayInputHandler gameplayInputHandler;
    [SerializeField] private CameraHandler cameraHandler;
    [SerializeField] private PlayerManager playerManager;

    private void Update()
    {
        rawInputCameraMovement = gameplayInputHandler.getRawInputCamera();
        cameraHandler.UpdateRawInputMovement(rawInputCameraMovement);
        playerManager.UpdateRawMovement(gameplayInputHandler.getRawInputMovement());
    }
}
