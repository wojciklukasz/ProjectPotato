using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class InGameMenu : MonoBehaviour
{
    [SerializeField] protected ButtonsHandler buttons;
    [SerializeField] protected GameObject menu;
    [SerializeField] protected Button firstSelectedButton;
    public UnityAction OnEnable;
    public UnityAction OnDisable;

    protected abstract void ShowMenu();
    protected abstract void HideMenu();

}
