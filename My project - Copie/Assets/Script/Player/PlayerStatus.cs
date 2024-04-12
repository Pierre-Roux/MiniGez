using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int MaxLife = 10;
    public int CurrentLife;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLife = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentLife <= 0)
        {
            Object.Destroy(this.gameObject);  
        }        
    }
}
