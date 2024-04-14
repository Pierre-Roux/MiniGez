using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Spine.Unity;
using Unity.VisualScripting;
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
    private Collider2D ColliderInFight;
    private GameManagerScript GameManager;
    private bool Dead;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        canAttack = true;
        CurrentLife = MaxLife;
        gameObject.tag = "Units"; 
        Etat = "Move";
        GameManager.UnitsOnBoard.Add(this.gameObject);
        Dead = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
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
                if (EndZone != null) 
                {
                    t = speed * Time.deltaTime / 1000;
                    transform.position = Vector3.MoveTowards(transform.position, EndZone.transform.position,t); 
                }       
            }

            if (ColliderInFight.IsDestroyed())
            {
                Etat = "Move";
                GetComponent<SkeletonAnimation>().AnimationName = "FLY"; 
            }
        }
    }

    private void OnTriggerStay2D(Collider2D ObjectCollide)
    {
        try
        {
            // Check if the collider that entered the trigger is the Defence
            if (ObjectCollide.gameObject.CompareTag("Defence"))
            {
                ColliderInFight = ObjectCollide;
                Etat = "Fight";
                GetComponent<SkeletonAnimation>().AnimationName = "ATTACK";

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
                    // Do something when the player enters the trigger
                    ObjectCollide.gameObject.GetComponent<Def_Wall_Behavior>().CurrentLife += -1;
                    if (ObjectCollide.gameObject.GetComponent<Def_Wall_Behavior>().CurrentLife <= 0) 
                    {
                        if (ObjectCollide != null)
                        {
                            ObjectCollide.transform.GetComponent<PolygonCollider2D>().enabled = false;
                            if (ObjectCollide.name.Contains("Barricade"))
                            {
                                StartCoroutine(DeathBarricade(ObjectCollide));
                            }
                            ObjectCollide.transform.GetComponent<SpriteRenderer>().sprite = ObjectCollide.transform.GetComponent<Def_Wall_Behavior>().Wall_KO; 
                        }
                        Etat = "Move";
                        GetComponent<SkeletonAnimation>().AnimationName = "FLY";
                    }
                    Etat = "Move";
                    GetComponent<SkeletonAnimation>().AnimationName = "FLY";
                    canAttack = false;
                }
            } else if (ObjectCollide.gameObject.CompareTag("Tower"))
            {
                ColliderInFight = ObjectCollide;
                Etat = "Fight";
                GetComponent<SkeletonAnimation>().AnimationName = "ATTACK";

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
                    // Do something when the player enters the trigger
                    ObjectCollide.gameObject.GetComponent<Def_Wall_Behavior>().CurrentLife += -1;
                    if (ObjectCollide.gameObject.GetComponent<Def_Wall_Behavior>().CurrentLife <= 0) 
                    {
                        Debug.Log("Nom de la tour casse   " + ObjectCollide.name);
                        if (ObjectCollide.name.Contains("Sprite"))
                        { 
                            StartCoroutine(DeathTower(ObjectCollide));
                        }
                        Etat = "Move";
                        GetComponent<SkeletonAnimation>().AnimationName = "FLY";
                    }
                    canAttack = false;
                }
            }
            else if (ObjectCollide.gameObject.CompareTag("Bullet"))
            {
                    CurrentLife += -1;
                    if (CurrentLife <= 0)
                    {
                        GameManager.CurrentLife += -1;
                        StartCoroutine(DeathAnim()); 
                    }
            } 
            else if (ObjectCollide.gameObject.CompareTag("EndZone"))
            {
                Destroy(this.gameObject);       
            } 
        }
        catch
        {
            Etat = "Move";
            GetComponent<SkeletonAnimation>().AnimationName = "FLY";
        }  
    }

    IEnumerator DeathAnim()
    {
        Dead = true;
        GetComponent<StudioEventEmitter>().Play();
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SkeletonAnimation>().AnimationName = "DEATH";
        yield return new WaitForSeconds(0.8f); 
        Destroy(this.gameObject);  
        yield break;
    }

    IEnumerator DeathBarricade(Collider2D ObjectCollide)
    {
        ObjectCollide.transform.GetComponent<StudioEventEmitter>().Play();
        yield return new WaitForSeconds(2f); 
        Destroy(ObjectCollide.gameObject); 
        yield break;
    }

    IEnumerator DeathTower(Collider2D ObjectCollide)
    {
        ObjectCollide.transform.GetComponent<StudioEventEmitter>().Play();
        yield return new WaitForSeconds(1f); 
        ObjectCollide.transform.GetComponent<PolygonCollider2D>().enabled = false;
        ObjectCollide.transform.GetComponent<SpriteRenderer>().sprite = ObjectCollide.transform.GetComponent<Def_Wall_Behavior>().Tower_KO;
        ObjectCollide.transform.parent.transform.GetComponent<Tower>().enabled = false; 
        yield break;
    }
}
