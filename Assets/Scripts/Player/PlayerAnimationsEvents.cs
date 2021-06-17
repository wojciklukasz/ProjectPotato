using UnityEngine;

public class PlayerAnimationsEvents : MonoBehaviour
{
    public PlayerManager playerManager;

    public void PlayerDeath()
    {
        playerManager.OnDeath?.Invoke();
    }
}
