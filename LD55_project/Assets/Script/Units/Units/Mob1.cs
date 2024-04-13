using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1 : MonoBehaviour
{
    public GameObject EndZone;
    public float speed = 0.1f; // Speed of mob movement
    private float t;
    public int MaxLife;
    private int CurrentLife;
    private bool canAttack;
    public float FireRate;
    private float timer;
    public CircleCollider2D CircleCollide;
    private String Etat;

    // Start is called before the first frame update
    void Start()
    {
        //EndZone = GameObject.FindGameObjectWithTag("EndZone").GetComponent<Transform>(); 
        canAttack = true;
        CurrentLife = MaxLife;
        gameObject.tag = "Units"; 
        Etat = "Move";
    }

    // Update is called once per frame
    void Update()
    {
        if (Etat == "Move")
        {
            if (EndZone != null) 
            {
                t = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, EndZone.transform.position,t);
            }
        }
        else
        {
                t = speed * Time.deltaTime / 1000;
                transform.position = Vector3.MoveTowards(transform.position, EndZone.transform.position,t);        
        }
    }

    private void OnTriggerStay2D(Collider2D ObjectCollide)
    {
        // Check if the collider that entered the trigger is the Defence
        if (ObjectCollide.gameObject.CompareTag("Defence"))
        {
            Etat = "Fight";
            if(!canAttack)
            {
                timer += Time.deltaTime;
                if(timer > FireRate)
                {
                    canAttack = true;
                    timer = 0;
                }
            }

            if (canAttack) 
            {
                Debug.Log("hit Wall");
                // Do something when the player enters the trigger
                ObjectCollide.gameObject.GetComponent<Def_Wall_Behavior>().CurrentLife += -1;
                if (ObjectCollide.gameObject.GetComponent<Def_Wall_Behavior>().CurrentLife <= 0) 
                {
                    Destroy(ObjectCollide.gameObject);  
                    Etat = "Move";
                }
                canAttack = false;
            }
        }
        else if (ObjectCollide.gameObject.CompareTag("Bullet"))
        {
            if (ObjectCollide.gameObject.GetComponent<bulletscript>().AlreadyHit == false)
            {
                Debug.Log("hited");
                if (CurrentLife <= 0)
                {
                    Destroy(this.gameObject);  
                }
                else
                {
                    CurrentLife += -1;
                }
            }
            ObjectCollide.gameObject.GetComponent<bulletscript>().AlreadyHit = true;
        }
    }
}
