using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates_Spawner1 : MonoBehaviour
{
    public Mob1 Imp;
    public Mob1 Devil;
    private Mob1 LastSpawned;
    public GameObject EndZone;
    public float SpawnRate;
    public int MaxLife;
    public int CurrentLife;
    private bool canSpawn;
    private float timer;
    private GameManagerScript GameManager;
    public List<int> ListNbMonster = new List<int>();
    public List<float> DelayBetweenVague = new List<float>();
    public int SpawnerNumero;
    public bool CoroutineStarted ;

    // Start is called before the first  frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        CurrentLife = MaxLife;
        canSpawn = true;

        ListNbMonster = GameManager.ListNbMonster;
        DelayBetweenVague = GameManager.DelayBetweenVague;
        CoroutineStarted = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameEtat == "Play_Phase1")
        {
            return;
        }
        else
        {
            if (!CoroutineStarted)
            {
                StartCoroutine(SpawnLoop());  
                CoroutineStarted = true;
            }
        }
    }

    public void Spawn(int Nombre, int i)
    {
        if (i == 0)
        {   

            StartCoroutine(IntsantiateImp(SpawnRate,Nombre));                             

        }
        else if(i == 1)
        {
            StartCoroutine(IntsantiateDevil(SpawnRate,Nombre));      
        }
        else if (i == 2)
        {
            StartCoroutine(IntsantiateGIGAImp(SpawnRate,Nombre));      
        }
    }
    IEnumerator IntsantiateImp(float Time, int Nombre)
    {
        for ( int y = 0; y < Nombre; y++)
        {
            LastSpawned = Instantiate(Imp, transform.position + new Vector3(1,1,0), Quaternion.identity);
            LastSpawned.gameObject.GetComponent<Mob1>().EndZone = EndZone;
            yield return new WaitForSeconds(Time);
        }
    }

    IEnumerator IntsantiateDevil(float Time, int Nombre)
    {
        for ( int y = 0; y < Nombre; y++)
        {
            LastSpawned = Instantiate(Devil, transform.position + new Vector3(1,1,0), Quaternion.identity);
            LastSpawned.gameObject.GetComponent<Mob1>().EndZone = EndZone;
            yield return new WaitForSeconds(Time);
        }
    }

    IEnumerator IntsantiateGIGAImp(float Time, int Nombre)
    {
        for ( int y = 0; y < Nombre; y++)
        {
            LastSpawned = Instantiate(Imp, transform.position + new Vector3(1,1,0), Quaternion.identity);
            LastSpawned.gameObject.GetComponent<Mob1>().EndZone = EndZone;
            yield return new WaitForSeconds(Time);
        }
    }

    IEnumerator SpawnLoop()
    {
        if (SpawnerNumero == 0)
        {  
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(this.name + " a spawn : " + ListNbMonster[i] + " de type " + i);
                Spawn(ListNbMonster[i],i);
            }
        }
        else if (SpawnerNumero == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log("SpawnMonstreType");
                Spawn(ListNbMonster[i+3],i);
            }
        }
        else if (SpawnerNumero == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log("SpawnMonstreType");
                Spawn(ListNbMonster[i+6],i);
            }
        }
        yield break;
    }
}
