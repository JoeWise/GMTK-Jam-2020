using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicModule : TimoModuleBase
{
    public static AudioSource pianoSource;

    // Start is called before the first frame update
    void Start()
    {
        pianoSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!taskInQueue)
        {
            float roll = Random.Range(1, 1000);
            //Debug.Log("roll: " + roll.ToString());

            if (roll == 50)
            {
                Debug.Log("Adding music task");

                string prompt = "Hey Timo, play me a song";

                task = new Task(prompt, 10.0f, this);
                AddTaskToQueue(task);


                PianoKey.keyStrikes = 0;
            }
        }
        else
        {
            if(PianoKey.keyStrikes >= 5)
            {
                OnTaskSatisfied();
            }
        }
    }

    public void OnWindowClose()
    {
        PianoKey.keyStrikes = 0;
    }

}


