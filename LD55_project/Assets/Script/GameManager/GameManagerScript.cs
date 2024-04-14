using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public String GameEtat;
    public int GlobalLife;
    public int CurrentLife;
    public List<GameObject> UnitsOnBoard = new List<GameObject>();
    public List<int> ListNbMonster = new List<int>();
    public List<float> DelayBetweenVague = new List<float>();    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            ListNbMonster.Add(0);
        }
        for (int i = 0; i < 9; i++)
        {
            DelayBetweenVague.Add(0);
        }

        GameEtat = "Play_Phase1";
        CurrentLife = GlobalLife;
    }

    // Update is called once per frame
    void Update()
    {
        // Si en jeux
        if (GameEtat == "Play_Phase2")
        {
            if (CurrentLife <= 0 )
            {
                Debug.Log("Perdu");
                ClearUnits();
                GameEtat = "Play_Phase2";
            }
        }
        else if (GameEtat == "Play_Phase1") 
        {

        }

    }

    public void ClearUnits()
    {
        foreach (var unit in UnitsOnBoard)
        {
            if (unit != null)
            {
                Destroy(unit.gameObject);
            }
        }
    }
}
