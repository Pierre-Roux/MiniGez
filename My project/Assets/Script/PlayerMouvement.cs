using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMouvement : MonoBehaviour
{
    public Vector3 Droite ;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        forward();
        Debug.Log(this.transform.position);
    }

    void forward(){
     
     if (UnityEngine.Input.GetKey("space")){
        Droite = new Vector3(10*Time.deltaTime,0,0);
        this.transform.position = this.transform.position + Droite;
     }

    }
}
