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
    [SerializeField] private bool isDefeatMenu = false;
    [SerializeField] private WinMenu winMenu;
    [SerializeField] private DefeatMenu defeatMenu;
    [SerializeField] private TriggerBattle triggerBoss;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private BossManager boss;
    [SerializeField] private bool isWinMenu = false;
    [SerializeField] private BoxCollider winGate;
    [SerializeField] private TriggerWinGame triggerWin;

    private void Awake()
    {
        gameplayUI.SetHealth(playerManager.playerStats.Health, true);
        gameplayUI.SetHealsAmount(playerManager.GetHealsAmount());
        gameplayUI.ShowPlayerUI();
        gameplayInputHandler.OnPauseAction += Pause;
        pauseMenu.OnChangePauseState += ChangePauseStateOnButton;
        playerManager.OnHealthUpdate += UpdateHealthBar;
        playerManager.OnDeath += LoseGame;
        triggerBoss.OnStartBattle += TriggerBossBattle;
        playerManager.OnHealingUIUpdate += UpdateHealingAmount;
        boss.OnDeath += WinGame;
        winGate.enabled = false;
        triggerWin.OnWin += EnableWinMenu;
    }

    private void Start()
    {
        musicManager.PlayMusic("MainMusic");
    }

    private void Update()
    {
        rawInputCameraMovement = gameplayInputHandler.getRawInputCamera();
        cameraHandler.UpdateRawInputMovement(rawInputCameraMovement);
        playerManager.UpdateRawMovement(gameplayInputHandler.getRawInputMovement());
    }

    private void Pause()
    {
        if (!isPause && !isDefeatMenu && !isWinMenu)
        {
            isPause = true;
            print("PAUSE");
            pauseMenu.OnEnable?.Invoke();
            gameplayInputHandler.SwitchActionMapToUI();
        }
        else if (!isDefeatMenu && !isWinMenu)
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

    private void UpdateHealthBar()
    {
        print("UPDATE HEALTH BAR");
        gameplayUI.SetHealth(playerManager.Health, false);
    }

    private void LoseGame()
    {
        print("Defeat MENU");
        isDefeatMenu = true;
        gameplayInputHandler.SwitchActionMapToUI();
        defeatMenu.OnEnable?.Invoke();
    }

    private void TriggerBossBattle()
    {
        print("BOSS BATTLE TRIGGER");
        musicManager.PlayMusic("BossMusic");
        boss.OnStartBattle?.Invoke();
        //show boss hp bar
    }

    private void UpdateHealingAmount()
    {
        print("HEALS UPDATE");
        gameplayUI.SetHealsAmount(playerManager.GetHealsAmount());
    }

    private void WinGame()
    {
        print("Win MENU");
        musicManager.PlayMusic("MainMusic");
        winGate.enabled = true;
    }

    private void EnableWinMenu()
    {
        isWinMenu = true;
        gameplayInputHandler.SwitchActionMapToUI();
        winMenu.OnEnable?.Invoke();
    }
}
