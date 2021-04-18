using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "EntityStats/PlayerStats")]
public class Stats : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }

    public float RotationSpeed
    {
        get { return rotationSpeed; }
    }
}
