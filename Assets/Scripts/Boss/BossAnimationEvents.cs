using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    public GameObject collider1;
    public GameObject collider2;

    public void EnableCollider1()
    {
        collider1.SetActive(true);
    }

    public void DisableCollider1()
    {
        collider1.SetActive(false);
    }

    public void EnableCollider2()
    {
        collider2.SetActive(true);
    }

    public void DisableCollider2()
    {
        collider2.SetActive(false);
    }

    public void DisableAllColliders()
    {
        collider1.SetActive(false);
        collider2.SetActive(false);
    }
}
