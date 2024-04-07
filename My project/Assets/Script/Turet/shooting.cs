    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos; 
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float minDistanceToFire ;
    public Transform Player;
    public GameObject reversebullet;

    // Start is called before the first frame update
    void Start()
    {
        minDistanceToFire= 13.08f;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);   

        Vector3 rotation = mousePos - transform.position; 

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire)
        {
           timer += Time.deltaTime;
           if(timer > timeBetweenFiring)
           {
                canFire = true;
                timer = 0;


           }
        }

        Debug.Log("distance souris : "+Vector3.Distance(Player.transform.position, mousePos));
        Debug.Log(minDistanceToFire);
        
        

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

