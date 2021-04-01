using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float maxDistance = 4.0f;
    [SerializeField] private float smooth = 10.0f;
    private Vector3 dollyDir;
    [SerializeField] private float distance;

    private void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    private void Update()
    {
        Vector3 desiredCameraPosition = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPosition, out hit))
        {
            //if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy" && hit.collider.tag != "Hitbox" && hit.collider.tag != "WeaponHitbox")
            if (hit.collider.tag == "CollisionForCamera")
                distance = Mathf.Clamp((hit.distance * 0.86f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
