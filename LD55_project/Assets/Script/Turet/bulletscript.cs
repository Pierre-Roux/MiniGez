using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public bool AlreadyHit;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float Force;
    // Start is called before the first frame update
    void Start()
    {
      AlreadyHit = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}