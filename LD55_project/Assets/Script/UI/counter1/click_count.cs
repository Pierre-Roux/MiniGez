using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;
using Spine.Unity;

public class click_count : MonoBehaviour
{
    public TextMeshProUGUI TextMeshpro1;
    public TextMeshProUGUI TextMeshpro2;
    public TextMeshProUGUI TextMeshpro3;
    public TextMeshProUGUI TextMeshpro4;
    public TextMeshProUGUI TextMeshpro5;
    public TextMeshProUGUI TextMeshpro6;
    public TextMeshProUGUI TextMeshpro7;

    public GameManagerScript Gamemanager;

    public GameObject Phase1Panel;

    private StudioEventEmitter Minus_sound;
    private StudioEventEmitter Plus_sound;
    private StudioEventEmitter Start_sound;

    public void AddImp()
    {
        if (int.Parse(TextMeshpro7.text)-5 >= 0)
        {
            Gamemanager.ListNbMonster[0]++;
            TextMeshpro1.text = Gamemanager.ListNbMonster[0].ToString();
            TextMeshpro7.text = (int.Parse(TextMeshpro7.text)-5).ToString();  
            Plus_sound.Play();          
        }

    }
    public void AddImp2()
    {
        if (int.Parse(TextMeshpro7.text)-5 >= 0)
        {
            Gamemanager.ListNbMonster[3]++;
            TextMeshpro2.text = Gamemanager.ListNbMonster[3].ToString();
            TextMeshpro7.text = (int.Parse(TextMeshpro7.text)-5).ToString();    
            Plus_sound.Play();           
        }
    }
    public void AddImp3()
    {
        if (int.Parse(TextMeshpro7.text)-5 >= 0)
        {
            Gamemanager.ListNbMonster[6]++;
            TextMeshpro3.text = Gamemanager.ListNbMonster[6].ToString();
            TextMeshpro7.text = (int.Parse(TextMeshpro7.text)-5).ToString();     
            Plus_sound.Play();         
        }
    }

    public void DelImp()
    {
        Gamemanager.ListNbMonster[0]--;
        TextMeshpro1.text = Gamemanager.ListNbMonster[0].ToString();
        TextMeshpro7.text = (int.Parse(TextMeshpro7.text)+5).ToString();
        Minus_sound.Play();   
    }
    public void DelImp2()
    {
        Gamemanager.ListNbMonster[3]--;
        TextMeshpro2.text = Gamemanager.ListNbMonster[3].ToString();
        TextMeshpro7.text = (int.Parse(TextMeshpro7.text)+5).ToString();
        Minus_sound.Play();  
    }
    public void DelImp3()
    {
        Gamemanager.ListNbMonster[6]--;
        TextMeshpro3.text = Gamemanager.ListNbMonster[6].ToString();
        TextMeshpro7.text = (int.Parse(TextMeshpro7.text)+5).ToString();
        Minus_sound.Play();  
    }

    public void AddDevil()
    {
        if (int.Parse(TextMeshpro7.text)-15 >= 0)
        {
            Gamemanager.ListNbMonster[1]++;
            TextMeshpro4.text = Gamemanager.ListNbMonster[1].ToString();
            TextMeshpro7.text = (int.Parse(TextMeshpro7.text)-15).ToString(); 
            Plus_sound.Play();              
        }
    }
    public void AddDevil2()
    {
        if (int.Parse(TextMeshpro7.text)-15 >= 0)
        {
            Gamemanager.ListNbMonster[4]++;
            TextMeshpro5.text = Gamemanager.ListNbMonster[4].ToString();
            TextMeshpro7.text = (int.Parse(TextMeshpro7.text)-15).ToString();     
            Plus_sound.Play();          
        }
    }
    public void AddDevil3()
    {
        if (int.Parse(TextMeshpro7.text)-15 >= 0)
        {
            Gamemanager.ListNbMonster[7]++;
            TextMeshpro6.text = Gamemanager.ListNbMonster[7].ToString();
            TextMeshpro7.text = (int.Parse(TextMeshpro7.text)-15).ToString();     
            Plus_sound.Play();          
        }
    }

    public void DelDevil()
    {
        Gamemanager.ListNbMonster[1]--;
        TextMeshpro4.text = Gamemanager.ListNbMonster[1].ToString();
        TextMeshpro7.text = (int.Parse(TextMeshpro7.text)+15).ToString();
        Minus_sound.Play();   
    }
    public void DelDevil2()
    {
        Gamemanager.ListNbMonster[4]--;
        TextMeshpro5.text = Gamemanager.ListNbMonster[4].ToString();
        TextMeshpro7.text = (int.Parse(TextMeshpro7.text)+15).ToString();
        Minus_sound.Play();  
    }
    public void DelDevil3()
    {
        Gamemanager.ListNbMonster[7]--;
        TextMeshpro6.text = Gamemanager.ListNbMonster[7].ToString();
        TextMeshpro7.text = (int.Parse(TextMeshpro7.text)+15).ToString();
        Minus_sound.Play();  
    }

    public void PlayGame()
    {
        Phase1Panel.SetActive(false);
        Start_sound.Play();
        Gamemanager.GameEtat = "Play_Phase2";
    }

    void Start()
    {
        StudioEventEmitter[] emitters = GetComponents<StudioEventEmitter>();

        int i = 0;

        // Parcourez la liste des StudioEventEmitters
        foreach (StudioEventEmitter emitter in emitters)
        {
            
            if (i == 0)
            {
                Plus_sound = emitter;
            }
            else if (i == 1)
            {
                Minus_sound = emitter;
            }
            else if (i == 2)
            {
                Start_sound = emitter;
            }
            i++;
        }
    }
     void Update()
    {
    
        
    }
}
