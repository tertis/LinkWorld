using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Ground : MonoBehaviour, Control.IClickable
{
    public int type { set; get; }
    public Material mat { set; get; }

    void Start()
    {

    }

    public void OnSelected()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void OnReleased()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}

