using UnityEngine;
using UnityEngine.Events;

public class TriggerWinGame : MonoBehaviour
{
    public UnityAction OnWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("CameraCollision") && other.gameObject.layer != this.gameObject.layer && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnWin?.Invoke();
        }
    }
}
