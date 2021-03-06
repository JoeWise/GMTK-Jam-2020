﻿using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : Singleton<WindowManager>
{
    public GameObject[] icons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableIcons()
    {
        foreach( GameObject icon in icons)
        {
            icon.SetActive(false);
        }
    }

    public void EnableIcons()
    {
        foreach (GameObject icon in icons)
        {
            icon.SetActive(true);
        }
    }
}
