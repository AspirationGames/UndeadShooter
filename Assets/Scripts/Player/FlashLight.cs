using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float maxBattery = 1;
    [SerializeField] float batteryDecay = .05f;

    float maxIntensity;
    float maxAngle;
    float currentBattery;
    Light lightComponent;

    private void Awake() 
    {
        lightComponent = GetComponent<Light>();    
    }
    private void Start() 
    {
        currentBattery = maxBattery; 
        maxIntensity = lightComponent.intensity;
        maxAngle = lightComponent.spotAngle;
           
    }

    private void Update() 
    {
        DepleteBattery();
        UpdateLightIntensity();
        UpdateLightAngle();
    }

    void DepleteBattery()
    {
        currentBattery -= batteryDecay;
    }

    void UpdateLightIntensity()
    {
        lightComponent.intensity = maxIntensity * currentBattery;
    }
    private void UpdateLightAngle()
    {
        lightComponent.spotAngle = maxAngle * currentBattery;
    }
    public void IncreaseBattery(float batteryPickUpPower)
    {
        
         currentBattery = Mathf.Clamp(currentBattery + batteryPickUpPower, 0, maxBattery + batteryDecay);
    
    }
}
