using UnityEngine;
using UnityEngine.Events;

public class HitboxCollider : MonoBehaviour
{
    public UnityAction OnKillCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("CameraCollision") && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "Weapon") //collision with weapon
        {
            Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
        }
        else if (this.gameObject.layer != LayerMask.NameToLayer("Enemy") && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "KillPlayer") //insta kill player - lava
        {
            Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
            OnKillCollision?.Invoke();
        }
    }
}
