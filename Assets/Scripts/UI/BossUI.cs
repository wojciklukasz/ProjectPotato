using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject hpBarObj;

    public void EnableHPBar()
    {
        hpBarObj.SetActive(true);
    }

    public void DisableHPBar()
    {
        hpBarObj.SetActive(false);
    }

    public void UpdateHealthBar(float amount, bool setMaxVal)
    {
        if (setMaxVal) healthBar.maxValue = amount;
        healthBar.value = amount;
    }
}
