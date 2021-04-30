using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private EnemyMovement movement;
  
  

    private void Awake()
    {
        Animator anim = enemyObject.GetComponent<Animator>();
        movement.EnemyAnimator = anim;

    }

   
    void Update()
    {
        movement.MoveEnemy();
    }
}
