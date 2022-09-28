using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera fpCamera;
    [SerializeField] float fireRange = 100f;

    [SerializeField] int damage = 5;

    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject bloodEffect;
    [SerializeField] Ammo ammo;
    [SerializeField] AmmoType ammoType;

    [SerializeField] float fireRate = 0.5f;

    ParticleSystem muzzleFlash;

    bool canFire = true;

    private void Awake()
    {
        muzzleFlash = GetComponentInChildren<ParticleSystem>();    
    }
    private void Update() 
    {
        if (Input.GetButton("Fire1"))
        {
            PullTrigger();
        }    
    }

    private void OnEnable() 
    {
        canFire = true;
        ammo.SetEquipedAmmoSlot(this.ammoType);    
    }

    void PullTrigger()
    {
        if(ammo.GetCurrentAmmo() <= 0)
        {
            return;
        }
        else if(canFire)
        {
            StartCoroutine(FireWeapon());
        }
        

    }

    IEnumerator FireWeapon()
    {
        canFire = false;
        PlayMuzzleFlash();
        ProcessRayCast();
        ammo.ReduceAmmo(ammoType, 1);

        yield return new WaitForSeconds(fireRate); //we use our fire rate to determine the speed at which the weapon can be fired

        canFire = true;

    }


    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(fpCamera.transform.position, fpCamera.transform.forward, Color.magenta, 2f);

        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, fireRange))
        {   
            
            
            
            //Enemy Hit
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null) 
            {
                
                PlayBloodEffect(hit);
                //Reduce Enemy Health
                enemyHealth.ReduceHealth(damage);
                

            }

        }
        else //not hit on anything
        {
            PlayHitEffect(hit);
            return;
        }
    }

    private void PlayHitEffect(RaycastHit hit)
    {
       GameObject instance = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(instance, 1f);
    }
    private void PlayBloodEffect(RaycastHit hit)
    {
       GameObject instance = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(instance, 1f);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, fireRange);
            
    }
}
