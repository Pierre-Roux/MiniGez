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
      mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
      
      rb = GetComponent<Rigidbody2D>();
      mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
      
      Vector3 direction = mousePos - transform.position;
      Vector3 rotation = transform.position - mousePos;
      
      rb.velocity = new Vector2(direction.x, direction.y).normalized * Force; 
      
      float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0, 0, rot + 90);  

      gameObject.tag="Bullet"; 
      AlreadyHit = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}