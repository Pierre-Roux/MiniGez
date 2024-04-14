using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Spine.Unity;

public class Minus_count: MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public GameManagerScript Gamemanager;
    public int TargetInList;

    public void ButonPressed()
    {
        if (Gamemanager.ListNbMonster[TargetInList] == 0)
        {
            Gamemanager.ListNbMonster[TargetInList] = 0;
        }
        else
        {
            Gamemanager.ListNbMonster[TargetInList]--;
        }
        numberText.text = Gamemanager.ListNbMonster[TargetInList].ToString();
    }
    void Start()
    {

    }
     void Update()
    {
    
        
    }
}
