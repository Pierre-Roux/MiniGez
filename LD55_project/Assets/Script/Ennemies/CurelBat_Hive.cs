using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurelBat_Hive : MonoBehaviour
{
    public CruelBat Ennemie;
    public float SpawnRate;
    public int MaxLife;
    public int CurrentLife;
    private bool canSpawn;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLife = MaxLife;
        canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canSpawn)
        {
            timer += Time.deltaTime;
            if(timer > SpawnRate)
            {
                canSpawn = true;
                timer = 0;
            }
        }

        if (canSpawn) 
        {
            Instantiate(Ennemie, transform.position, Quaternion.identity);
            canSpawn = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D ObjectCollide)
    {
        if (ObjectCollide.gameObject.CompareTag("Bullet"))
        {
            if (CurrentLife <= 0)
            {
                Object.Destroy(this.gameObject);  
            }
            else
            {
                CurrentLife += -1;
            }
        }
    }

}
