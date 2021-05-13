using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private ButtonsHandler buttons;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credtisMenu;
    [SerializeField] private Button firstSelectedButtonMainMenu;
    [SerializeField] private Button firstSelectedButtonCreditsMenu;

    private void Awake()
    {
        credtisMenu.SetActive(false);
        mainMenu.SetActive(true);
        MainMenuButtonsSubscribe();
        firstSelectedButtonMainMenu.Select();
    }

    private void StartGame()
    {
        print("START BUTTON");
        MainMenuButtonsUnsubscribe();
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        print("EXIT BUTTON");
        Application.Quit();
    }

    private void ShowCreditsMenu()
    {
        print("SHOW CREDIT BUTTON");
        MainMenuButtonsUnsubscribe();
        buttons.OnReturnClick += HideCreditsMenu;
        mainMenu.SetActive(false);
        credtisMenu.SetActive(true);
        firstSelectedButtonCreditsMenu.Select();
    }

    private void HideCreditsMenu()
    {
        print("HIDE CREDIT BUTTON");
        buttons.OnReturnClick -= HideCreditsMenu;
        credtisMenu.SetActive(false);
        mainMenu.SetActive(true);
        MainMenuButtonsSubscribe();
        firstSelectedButtonMainMenu.Select();
    }

    private void MainMenuButtonsSubscribe()
    {
        buttons.OnNewGameClick += StartGame;
        buttons.OnCreditsClick += ShowCreditsMenu;
        buttons.OnExitClick += ExitGame;
    }

    private void MainMenuButtonsUnsubscribe()
    {
        buttons.OnNewGameClick -= StartGame;
        buttons.OnCreditsClick -= ShowCreditsMenu;
        buttons.OnExitClick -= ExitGame;
    }

}
