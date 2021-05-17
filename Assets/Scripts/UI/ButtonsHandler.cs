using UnityEngine;
using UnityEngine.Events;

public class ButtonsHandler : MonoBehaviour
{
    public UnityAction OnNewGameClick;
    public UnityAction OnExitClick;
    public UnityAction OnCreditsClick;
    public UnityAction OnContinueClick;
    public UnityAction OnMainMenuClick;
    public UnityAction OnReturnClick;

    public void OnNewGameButton()
    {
        OnNewGameClick?.Invoke();
    }

    public void OnExitButton()
    {
        OnExitClick?.Invoke();
    }

    public void OnCreditsButton()
    {
        OnCreditsClick?.Invoke();
    }

    public void OnContinueButton()
    {
        OnContinueClick?.Invoke();
    }

    public void OnMainMenuButton()
    {
        OnMainMenuClick?.Invoke();
    }

    public void OnReturnButton()
    {
        OnReturnClick?.Invoke();
    }

}
