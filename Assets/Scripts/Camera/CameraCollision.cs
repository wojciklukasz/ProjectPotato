using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float maxDistance = 4.0f;
    [SerializeField] private float smooth = 10.0f;
    private Vector3 dollyDir;
    [SerializeField] private float distance;
    private RaycastHit hit;

    private void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    private void Update()
    {
        CorrectPosition();
    }

    private void CorrectPosition()
    {
        if(CheckCollision()) distance = Mathf.Clamp((hit.distance * 0.86f), minDistance, maxDistance);
        else distance = maxDistance;
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }

    private bool CheckCollision()
    {
        Vector3 desiredCameraPosition = transform.parent.TransformPoint(dollyDir * maxDistance);
        if (Physics.Linecast(transform.parent.position, desiredCameraPosition, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("CameraCollision")) return true;
            return false;
        }
        else return false;
    }
};
