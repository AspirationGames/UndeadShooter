using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hp = 100;
    public event Action OnDamageTaken;
    public event Action OnDeath;
    Animator enemyAnimator;

   

    private void Awake() 
    {
        
    }

    public void ReduceHealth(int damage)
    {
        
        OnDamageTaken?.Invoke();
        hp -= damage;
        Debug.Log(hp);
        if(hp <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        OnDeath?.Invoke();
        //Destroy(gameObject);
    }
}
