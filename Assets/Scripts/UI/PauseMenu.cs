using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : InGameMenu
{
    public UnityAction OnChangePauseState;

    private void Awake()
    {
        menu.SetActive(false);
        OnEnable += ShowMenu;
        OnDisable += HideMenu;
    }

    protected override void HideMenu()
    {
        print("HIDE MENU");
        UnsubcribeButtons();
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    protected override void ShowMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0; 
        firstSelectedButton.Select();
        firstSelectedButton.OnSelect(null);
        SubscribeButtons();
    }

    private void MainMenuReturn()
    {
        print("MAIN MENU");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        print("EXIT");
        Application.Quit();
    }

    private void ButtonContinue()
    {
        OnChangePauseState?.Invoke();
        HideMenu();
    }

    private void SubscribeButtons()
    {
        buttons.OnContinueClick += ButtonContinue;
        buttons.OnMainMenuClick += MainMenuReturn;
        buttons.OnExitClick += ExitGame;
    }

    private void UnsubcribeButtons()
    {
        buttons.OnContinueClick -= ButtonContinue;
        buttons.OnMainMenuClick -= MainMenuReturn;
        buttons.OnExitClick -= ExitGame;
    }

}
