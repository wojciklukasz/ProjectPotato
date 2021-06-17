using UnityEngine;

public class EnemyAnimationsEvent : MonoBehaviour
{
    public GameObject collider1;

    public void EnableCollider1()
    {
        collider1.SetActive(true);
    }

    public void DisableCollider1()
    {
        collider1.SetActive(false);
    }
}
