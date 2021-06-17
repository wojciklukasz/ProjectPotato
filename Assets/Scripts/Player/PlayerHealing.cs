using UnityEngine;

public class PlayerHealing : MonoBehaviour
{
    [SerializeField] private float healHpAmount=10f;
    private float nextHeal;
    [SerializeField] private float healSpeed = 0.9f;
    [SerializeField] private PlayerAnimations animations;
    [SerializeField] private int healsAmount = 25;

    public float HealSpeed
    {
        set { healSpeed = value; }
    }

    public PlayerAnimations Animations
    {
        set { animations = value; }
    }

    public int HealsAmount
    {
        set { healsAmount = value; }
        get { return healsAmount; }
    }

    public float Heal()
    {
        if (Time.time > nextHeal && healsAmount > 0)
        {
            nextHeal = Time.time + healSpeed;
            animations.PlayAnimation("Heal");
            healsAmount--;
            return healHpAmount;
        }
        else return 0;
    }
}
