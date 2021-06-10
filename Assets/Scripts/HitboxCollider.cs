using UnityEngine;
using UnityEngine.Events;

public class HitboxCollider : MonoBehaviour
{
    [SerializeField] private PlayerManager player;
    [SerializeField] private EnemyEntity enemyEntity;

    public UnityAction OnKillCollision;
    public UnityAction OnHit;

    private void Awake()
    {
        if(gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyEntity = gameObject.GetComponent<EnemyEntity>();
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Player") && !player)
        {
            player = gameObject.GetComponent<PlayerManager>();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("CameraCollision") && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "Weapon") //collision with weapon
        {
            Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
            if (gameObject.layer == LayerMask.NameToLayer("Enemy") && player.attackCounter==0) //enemy takes hit
            {
                enemyEntity.TakeDmg(player.dmg);
                player.attackCounter++;
            }
            else if (gameObject.layer == LayerMask.NameToLayer("Player")) //player takes hit
            {
                enemyEntity = other.transform.root.GetComponent<EnemyManager>();
                if(!enemyEntity) // add here ^ this but other script (if have different script :) ) - needs to be EnemyEntity
                {
                    print("Cant find enemy");
                }
                if (enemyEntity && enemyEntity.attackCounter == 0)
                {
                    enemyEntity.attackCounter++;
                    player.TakeDmg(enemyEntity.dmg);
                }
            }
            OnHit?.Invoke();
        }
        else if (this.gameObject.layer != LayerMask.NameToLayer("Enemy") && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "KillPlayer") //insta kill player - lava
        {
            Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
            OnKillCollision?.Invoke();
        }
    }
}
