using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount;
    

    private void OnTriggerEnter(Collider other) 
    {
        Ammo ammo = other.GetComponent<Ammo>();
        ammo.AddAmmo(ammoType, ammoAmount);

        Destroy(gameObject, 1f);
    }
}
