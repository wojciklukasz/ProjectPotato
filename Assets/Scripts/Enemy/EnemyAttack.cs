using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemyMovement movement;
    private int randomAttack;
    private bool close;


    public Animator EnemyAnimator
    {
        set { enemyAnimator = value; }
    }
    public bool Close
    {
        get { return this.close; }
        set { close = value; }
    }
    

    public IEnumerator Attack()
    {
        enemyAnimator.SetInteger("condition", 0);
        Close = true;
        randomAttack = 0;
        randomAttack = Random.Range(1, 4);
        switch (randomAttack)
        {
            case 1:
                Attack1();
                Debug.Log("atak1");
                break;
            case 2:
                Attack2();
                Debug.Log("atak2");
                break;
            case 3:
                Attack3();
                Debug.Log("atak3");
                break;
        }
        yield return new WaitForSeconds(2);
        //enemyAnimator.SetInteger("attack", 0);
        Close = false;
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
