using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public static int keyStrikes;

    public AudioClip note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyHit()
    {
        //Debug.Log("Key Hit");

        keyStrikes += 1;
        
        MusicModule.pianoSource.PlayOneShot(note);
    }
}
