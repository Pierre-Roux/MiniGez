using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DelaySelector_minus: MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public game_manager_behavior Gamemanager;
    public int TargetDelayInlist;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void ButoonPressed()
    {
        if (Gamemanager.ListDelay[TargetDelayInlist] == 0)
        {
            Gamemanager.ListDelay[TargetDelayInlist] = 0;
        }
        else
        {
            Gamemanager.ListDelay[TargetDelayInlist]--;
        }
        numberText.text = Gamemanager.ListDelay[TargetDelayInlist].ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
