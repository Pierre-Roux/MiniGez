using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Delete_light : MonoBehaviour
{
    // When the sprite appear 
    private void Awake()
    {
      StartCoroutine(waiter());
    }

    // create a delay for 2 seconds after that destroy the object 
    IEnumerator waiter()
    {
      yield return new WaitForSeconds(0.05f);
      Object.Destroy(this.gameObject);  
    }
}
