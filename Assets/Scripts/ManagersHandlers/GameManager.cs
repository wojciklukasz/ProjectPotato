using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 rawInputCameraMovement;
    [SerializeField] private GameplayInputHandler gameplayInputHandler;
    [SerializeField] private CameraHandler cameraHandler;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameplayUI gameplayUI;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private bool isPause = false;
    [SerializeField] private WinMenu winMenu;
    [SerializeField] private DefeatMenu defeatMenu;

    private void Awake()
    {
        gameplayUI.SetHealth(playerManager.playerStats.Health, true);
        gameplayUI.ShowPlayerUI();
        gameplayInputHandler.OnPauseAction += Pause;
        pauseMenu.OnChangePauseState += ChangePauseStateOnButton;
    }

    private void Update()
    {
        rawInputCameraMovement = gameplayInputHandler.getRawInputCamera();
        cameraHandler.UpdateRawInputMovement(rawInputCameraMovement);
        playerManager.UpdateRawMovement(gameplayInputHandler.getRawInputMovement());
    }

    private void Pause()
    {
        if (!isPause)
        {
            isPause = true;
            print("PAUSE");
            pauseMenu.OnEnable?.Invoke();
            gameplayInputHandler.SwitchActionMapToUI();
        }
        else
        {
            isPause = false;
            print("DISABLE PAUSE");
            pauseMenu.OnDisable?.Invoke();
            gameplayInputHandler.SwitchActionMapToPlayer();
        }
    }

    private void ChangePauseStateOnButton()
    {
        if (isPause)
        {
            isPause = false;
            gameplayInputHandler.SwitchActionMapToPlayer();
        }
        else
        {
            isPause = true;
            gameplayInputHandler.SwitchActionMapToUI();
        }
    }
}
