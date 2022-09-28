using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI ammoTypeText;

    Ammo ammo;

    private void Awake() 
    {
        ammo = FindObjectOfType<Ammo>();
    }
    void Start()
    {
        
    }


    void Update()
    {
        SetAmmoUI();
    }

    void SetAmmoUI()
    {
        ammoTypeText.text = $"{ammo.EquipedAmmoSlot.ammoType}";
        ammoText.text = $"{ammo.EquipedAmmoSlot.ammo}/{ammo.EquipedAmmoSlot.maxAmmo}";
    }
}
