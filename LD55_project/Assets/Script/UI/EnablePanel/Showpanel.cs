using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showpanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject Panel3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowPanel1()
    {
        if (Panel.gameObject.activeSelf)
        {
            Panel.gameObject.SetActive(false);
        }
        else
        {
            Panel.gameObject.SetActive(true);
        }
    }
    public void ShowPanel2()
    {
        if (Panel2.gameObject.activeSelf)
        {
            Panel2.gameObject.SetActive(false);
        }
        else
        {
            Panel2.gameObject.SetActive(true);
        }
    }
    public void ShowPanel3()
    {
        if (Panel3.gameObject.activeSelf)
        {
            Panel3.gameObject.SetActive(false);
        }
        else
        {
            Panel3.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
