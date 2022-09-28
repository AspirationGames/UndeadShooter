using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float aimFOV = 40f;
    [SerializeField] float defaultFOV = 60f;
    [SerializeField] float scopeFOV = 20f;
    [SerializeField] Vector3 weaponAimPosition = new Vector3 (-0.5f, 0f, 0.5f);
    [SerializeField] Vector3 weaponDefualtPosition = new Vector3 (0f, 0f, 0f);
    [SerializeField] float aimSpeed = 5f;
    [SerializeField] float aimMouseSensitivity = 0.5f;

    [SerializeField] bool hasScope = false;
    float defualtMouseSensitivity;
    RigidbodyFirstPersonController playerController;
    

    private void Awake() 
    {  
        playerController = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    private void Start() 
    {
        defualtMouseSensitivity = playerController.mouseLook.XSensitivity; //sine both sensitivity are the same we only need to get a refrense to the start value for one.    
    }
    
    private void Update() 
    {
        SetAimPosition();   
    }

    private void OnDisable() 
    {
        ResetFOV();    
    }
    public void SetAimPosition()
    {   
        
        if(Input.GetKey(KeyCode.Mouse1))
        {
            if(hasScope)
            {
                SetScopeFOV();
            }
            else
            {
                SetAimFOV();
            }
               
        }
        else
        {
            ResetFOV();
        }
        
    }

   void SetAimFOV()
    {
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, aimFOV,  aimSpeed * Time.deltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, weaponAimPosition, aimSpeed * Time.deltaTime);
        
        //Mouse Sensitivity
        playerController.mouseLook.XSensitivity = aimMouseSensitivity;
        playerController.mouseLook.YSensitivity = aimMouseSensitivity;
    }

    void SetScopeFOV()
    {
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, scopeFOV,  aimSpeed * Time.deltaTime);

        //Mouse Sensitivity
        playerController.mouseLook.XSensitivity = aimMouseSensitivity;
        playerController.mouseLook.YSensitivity = aimMouseSensitivity;
    }

    public void ResetFOV()
    {
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, defaultFOV, aimSpeed * Time.deltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, weaponDefualtPosition, aimSpeed  * Time.deltaTime);
        playerController.mouseLook.XSensitivity = defualtMouseSensitivity;
        playerController.mouseLook.YSensitivity = defualtMouseSensitivity;
    }

    
}
