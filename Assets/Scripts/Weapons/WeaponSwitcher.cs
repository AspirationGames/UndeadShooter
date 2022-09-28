using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex;

    List<Weapon> weapons;
    WeaponAim weaponAim;
    private void Start() 
    {
        Init();
    }

    private void Update() 
    {
        CheckForScrollInput();
    }

    private void Init()
    {
        weapons = new List<Weapon> (GetComponentsInChildren<Weapon>());
        EquipWeapon();
        
    }

    private void EquipWeapon()
    {
        foreach(Weapon weapon in weapons)
        {   
            if(weapons.IndexOf(weapon) == currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            
        }
    }

    private void CheckForScrollInput()
    {
        Vector2 scrollDelta = Input.mouseScrollDelta;

       if(scrollDelta.y == 0)
       {
           return;
       }
       if(scrollDelta.y > 0)
       {
           IncrementWeaponIndex(1);
           EquipWeapon();
       }
       else if(scrollDelta.y < 0)
       {
           IncrementWeaponIndex(-1);
           EquipWeapon();
       }
    }

    private void IncrementWeaponIndex(int increment)
    {
        if(currentWeaponIndex == (weapons.Count-1) && increment > 0)
        {
            currentWeaponIndex = 0;
            return;
        }
        else if(currentWeaponIndex == 0 && increment < 0)
        {
            currentWeaponIndex = (weapons.Count-1);
            return;
        }
        else
        {
            currentWeaponIndex = Mathf.Clamp((currentWeaponIndex+increment),0, (weapons.Count-1));
        }
        
    }
}
