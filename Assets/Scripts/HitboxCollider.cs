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
            if (gameObject.layer == LayerMask.NameToLayer("Enemy") && other.transform.root.gameObject.layer == LayerMask.NameToLayer("Player") && player.attackCounter==0) //enemy takes hit
            {
                Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
                enemyEntity.TakeDmg(player.dmg);
                player.attackCounter++;
            }
            else if (gameObject.layer == LayerMask.NameToLayer("Player") && other.transform.root.gameObject.layer == LayerMask.NameToLayer("Enemy")) //player takes hit
            {
                Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
                enemyEntity = other.transform.root.GetComponent<EnemyManager>();
                if(!enemyEntity) // add here ^ this but other script (if you have different script :) ) - needs to be EnemyEntity
                {
                    print("Cant find enemy");
                }
                if (enemyEntity && enemyEntity.attackCounter == 0)
                {
                    enemyEntity.attackCounter++;
                    player.TakeDmg(enemyEntity.dmg);
                    OnHit?.Invoke();
                }
            }
        }
        else if (this.gameObject.layer != LayerMask.NameToLayer("Enemy") && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "KillPlayer") //insta kill player - lava
        {
            Debug.Log("KOLIZJA" + this.gameObject.tag + " z " + other.gameObject.tag);
            OnKillCollision?.Invoke();
        }
    }
}
