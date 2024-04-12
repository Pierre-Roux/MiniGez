using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Delete : MonoBehaviour
{
    // When the sprite appear 
    private void Awake()
    {
      StartCoroutine(waiter());
    }

    // create a delay for 2 seconds after that destroy the object 
    IEnumerator waiter()
    {
      yield return new WaitForSeconds(2);
      Object.Destroy(this.gameObject);  
    }
}
