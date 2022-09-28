using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    PlayerHealth target; //place holder we will later define
    [SerializeField] int damage;

    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        
        if(target == null)
        {
            return;
        }
        else
        {
            Debug.Log("hurting player");
            target.GetComponent<PlayerHealth>().ReduceHealth(damage);
        }
        
        //reduce player health

    }


    
}
