using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject bloodSplatter;
    DeathHandler deathHandler;

    

    private void Awake() 
    {
        
    }

    private void Start() 
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    public void ReduceHealth(int damage)
    {   
        bloodSplatter.gameObject.SetActive(true);
        hp -= damage;

        if(hp <= 0)
        {
            PlayerDeath();
            
        }
    }

    public void PlayerDeath()
    {
        deathHandler.HandleDeath();
    }

    
}
