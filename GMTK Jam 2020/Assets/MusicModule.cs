using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicModule : TimoModuleBase
{
    public static AudioSource pianoSource;

    public string[] prompts;

    private void OnEnable()
    {
        CreateTask();
    }

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
            float roll = Random.Range(1, odds);
            //Debug.Log("roll: " + roll.ToString());

            if (roll == 50)
            {
                CreateTask();
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

    void CreateTask()
    {
        Debug.Log("Adding music task");

        string prompt = prompts[Random.Range(0, prompts.Length)];

        task = new Task(prompt, taskLength, this);
        AddTaskToQueue(task);


        PianoKey.keyStrikes = 0;
    }

    public void OnWindowClose()
    {
        PianoKey.keyStrikes = 0;
    }

}


