using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPickUp : MonoBehaviour
{
    [SerializeField] float batteryPickUpPower = 0.5f;


    private void OnTriggerEnter(Collider other) 
    {
        other.GetComponentInChildren<FlashLight>().IncreaseBattery(batteryPickUpPower);  
        Destroy(gameObject, 1f);  
    }
}
