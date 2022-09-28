using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;


    private void Start() 
    {
           
    }

    public void HandleDeath()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }


}
