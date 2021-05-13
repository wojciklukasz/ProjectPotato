using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private ButtonsHandler buttons;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credtisMenu;

    private void Awake()
    {
        credtisMenu.SetActive(false);
        mainMenu.SetActive(true);
        MainMenuButtonsSubscribe();
    }

    private void StartGame()
    {
        print("START BUTTON");
        //SceneManager.LoadScene(1);
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
    }

    private void HideCreditsMenu()
    {
        print("HIDE CREDIT BUTTON");
        buttons.OnReturnClick -= HideCreditsMenu;
        credtisMenu.SetActive(false);
        mainMenu.SetActive(true);
        MainMenuButtonsSubscribe();
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
