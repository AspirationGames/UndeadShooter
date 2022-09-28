using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    private void OnEnable() 
    {
        StartCoroutine(ShowBloodSplatter());    
    }

    IEnumerator ShowBloodSplatter()
    {

        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
