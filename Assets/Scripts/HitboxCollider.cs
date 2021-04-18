using UnityEngine;

public class HitboxCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "CollisionForCamera" && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "WeaponHitbox")
        {
            Debug.Log(this.gameObject.tag + "z" + other.gameObject.tag);
            Debug.Log("KOLIZJA");
        }
    }
}
