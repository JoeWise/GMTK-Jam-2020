using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class SFXManager : Singleton<SFXManager>
{
    public AudioSource audioSource;

    public AudioClip fail;
    public AudioClip succeed;
    public AudioClip newTask;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFail()
    {
        audioSource.PlayOneShot(fail);
    }

    public void PlaySucceed()
    {
        audioSource.PlayOneShot(succeed);
    }

    public void PlayNewTask()
    {
        audioSource.PlayOneShot(newTask);
    }
}
