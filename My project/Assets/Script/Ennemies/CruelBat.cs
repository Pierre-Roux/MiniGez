using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CruelBat : MonoBehaviour
{
    private Transform Player;
    public float speed = 0.1f; // Speed of Bat movement
    public float RotationSpeed = 0.1f; // Speed of Bat rotation
    private float t;
    public int MaxLife;
    private int CurrentLife;
    private bool canAttack;
    public float FireRate;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        t = speed * Time.deltaTime;
        canAttack = true;
        CurrentLife = MaxLife;
        gameObject.tag="Ennemie"; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) 
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,t);
            Vector3 direction = Player.transform.position - transform.position;


        }
    }

        // called when the cube hits the floor
    void OnCollisionStay2D(Collision2D ObjectCollide)
    {
        // Check if the collider that entered the trigger is the player
        if (ObjectCollide.gameObject.CompareTag("Player"))
        {
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
                Debug.Log("hit player");
                // Do something when the player enters the trigger
                ObjectCollide.gameObject.GetComponent<PlayerStatus>().CurrentLife += -1;
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
                    Object.Destroy(this.gameObject);  
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
