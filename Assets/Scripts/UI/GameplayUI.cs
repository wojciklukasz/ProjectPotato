using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthAmountText;

    public void SetHealth(float amount, bool setMaxVal)
    {
        if (setMaxVal) healthSlider.maxValue = amount;
        healthSlider.value = amount;
    }

    public void ShowPlayerUI()
    {
        healthSlider.gameObject.SetActive(true);
    }

    public void HidePlayerUI()
    {
        healthSlider.gameObject.SetActive(false);
    }

    public void SetHealsAmount(int amount)
    {
        healthAmountText.text = amount.ToString();
    }
}
