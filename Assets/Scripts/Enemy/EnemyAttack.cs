using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;

    private int randomAttack;
   

    public Animator EnemyAnimator
    {
        set { enemyAnimator = value; }
    }

    void Start()
    {
        Attack();
    }
  

    public IEnumerator Attack()
    {
        randomAttack = 0;
        randomAttack = Random.Range(1, 4);
        Debug.Log(randomAttack);
        switch (randomAttack)
        {
            case 1:
                Attack1();
                break;
            case 2:
                Attack2();
                break;
            case 3:
                Attack3();
                break;
        }
        yield return new WaitForSeconds(2);
        EnemyMovement.close = false;
    }
    public void Attack1()
    {
        enemyAnimator.SetInteger("attack", 1);
    }
    public void Attack2()
    {
        enemyAnimator.SetInteger("attack", 2);
 
    }
    public void Attack3()
    {
        enemyAnimator.SetInteger("attack", 3);
    }

}
