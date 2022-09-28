using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] List<AmmoSlot> ammoSlots;
    AmmoSlot equipedAmmoSlot;
    public AmmoSlot EquipedAmmoSlot
    {
        get
        {
            return equipedAmmoSlot;
        }
    }

    public void SetEquipedAmmoSlot(AmmoType weaponAmmoType)
    {   

       foreach(AmmoSlot ammoSlot in ammoSlots)
       {
           if(ammoSlot.ammoType == weaponAmmoType)
           {
               equipedAmmoSlot = ammoSlot;
               return;
           }
           else
           {
               continue;
           }
       }
        
    }

    public AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot ammoSlot in ammoSlots)
       {
           if(ammoSlot.ammoType == ammoType)
           {
               return ammoSlot;
           }
           else
           {
               continue;
           }
       }

       return null;
    }
    public int GetCurrentAmmo()
    {
        return equipedAmmoSlot.ammo;
    }

    public void AddAmmo(AmmoType ammoType, int amount)
    {
        
        GetAmmoSlot(ammoType).ammo += amount;
    }

    public void ReduceAmmo(AmmoType ammoType, int amount)
    {
        
        GetAmmoSlot(ammoType).ammo -= amount;
        
    }



}

[System.Serializable]
public class AmmoSlot
{
    public AmmoType ammoType;
    public int ammo = 10;
    public int maxAmmo = 100;
}

public enum AmmoType
{
    Pistol,
    Shotgun,
    Carbine,
    Sniper

}
