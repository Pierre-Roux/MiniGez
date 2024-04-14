using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Def_Wall_Behavior : MonoBehaviour
{
    public int MaxLife;
    public int CurrentLife;

    public Sprite Tower_KO;
    public Sprite Wall_KO;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLife = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D ObjectCollide)
    {

    }
}
