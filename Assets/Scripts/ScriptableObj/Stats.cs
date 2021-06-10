using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "EntityStats/PlayerStats")]
public class Stats : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float health;
    [SerializeField] private float dmg;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }

    public float RotationSpeed
    {
        get { return rotationSpeed; }
    }

    public float AttackSpeed
    {
        get { return attackSpeed; }
    }

    public float Health
    {
        get { return health; }
    }

    public float Dmg
    {
        get { return dmg; }
    }
}
