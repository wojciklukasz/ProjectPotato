using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    private float attackSpeed;
    [SerializeField] private Animator playerAnimator;

    public float AttackSpeed
    {
        set { attackSpeed = value; }
    }

    public Animator PlayerAnimator
    {
        set { playerAnimator = value; }
    }

    public void Attack()
    {
        playerAnimator.SetInteger("State", 1);
    }
}
