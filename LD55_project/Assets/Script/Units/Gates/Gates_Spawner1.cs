using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates_Spawner1 : MonoBehaviour
{
    public Mob1 Ennemie;
    private Mob1 LastSpawned;
    public GameObject EndZone;
    public float SpawnRate;
    public int MaxLife;
    public int CurrentLife;
    private bool canSpawn;
    private float timer;

    // Start is called before the first  frame update
    void Start()
    {
        CurrentLife = MaxLife;
        canSpawn = true;
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
            LastSpawned = Instantiate(Ennemie, transform.position + new Vector3(1,1,0), Quaternion.identity);
            LastSpawned.gameObject.GetComponent<Mob1>().EndZone = EndZone;
            canSpawn = false;
        }
        
    }
}
