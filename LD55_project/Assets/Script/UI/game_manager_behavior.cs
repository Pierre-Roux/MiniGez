using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager_behavior : MonoBehaviour

{
    public List<int> ListNbMonster = new List<int>();
    public List<int> ListDelay = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            ListNbMonster.Add(0);
        }
        for (int i = 0; i < 3; i++)
        {
            ListDelay.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
