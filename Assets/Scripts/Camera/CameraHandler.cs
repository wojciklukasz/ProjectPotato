using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Vector3 rawInputMovement;
    [SerializeField] private float CameraSpeed = 120.0f;
    [SerializeField] private GameObject CameraFollowObj;
    [SerializeField] private float clampAngle = 80.0f;
    [SerializeField] private float inputSensitivity = 150.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Awake()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotationY = rotation.y;
        rotationX = rotation.x;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update()
    { 
        Rotate();
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void Rotate()
    {
        rotationY += rawInputMovement.x * inputSensitivity * Time.deltaTime;
        rotationX += rawInputMovement.z * inputSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        transform.rotation = localRotation;
    }

    private void FollowTarget()
    {
        Transform target = CameraFollowObj.transform;

        float step = CameraSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void UpdateRawInputMovement(Vector3 newrawInputMovement)
    {
        rawInputMovement = newrawInputMovement;
    }
}
