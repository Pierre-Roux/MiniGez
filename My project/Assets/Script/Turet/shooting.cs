    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos; 
    public GameObject bullet;
    public GameObject reversebullet;
    public Transform bulletTransform;
    private bool canFire;
    private float timer;
    public float FireRate;
    private float minDistanceToFire ;
    public Transform Player;


    // Start is called before the first frame update
    void Start()
    {
        minDistanceToFire= 10.145f;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);   
       
        Vector3 rotation = mousePos - transform.position; 

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ+90);

        if(!canFire)
        {
           timer += Time.deltaTime;
           if(timer > FireRate)
           {
                canFire = true;
                timer = 0;
           }
        }
        
        // Si ma disctance souris est plus grande que ma distance minimal
        // canfire devient faux
        if (Input.GetMouseButton(0) && canFire)
        {
            if (Vector3.Distance(Player.transform.position, mousePos) > minDistanceToFire)
            {
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                canFire = false;   
        
            }
            else 
            {
                Instantiate(reversebullet, bulletTransform.position, Quaternion.identity);
                canFire = false;
            }
        }
    }
}

