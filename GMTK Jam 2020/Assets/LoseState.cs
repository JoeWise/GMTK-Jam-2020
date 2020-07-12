using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class LoseState : State
{
    public GameObject EndScreen;

    private void OnEnable()
    {
        EndScreen.SetActive(true);
        SFXManager.Instance.PlayGameOver();
    }

    private void OnDisable()
    {
        EndScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        ChangeState("Play");
    }
}
