using UnityEngine;

public class HitboxCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("CameraCollision") && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "Weapon")
        {
            Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
        }
    }
}
