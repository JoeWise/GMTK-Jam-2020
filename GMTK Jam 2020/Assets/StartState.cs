using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class StartState : State
{
    public GameObject startWindow;

    private void OnEnable()
    {
        startWindow.SetActive(true);
    }

    private void OnDisable()
    {
        startWindow.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Next();
    }
}
