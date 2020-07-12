using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModule : TimoModuleBase
{

    public string[] prompts;

    public bool picTaken = false;

    public CatEnvironment catEnvironment;

    private void OnEnable()
    {
        CreateTask();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!taskInQueue)
        {
            catEnvironment.displayCat = false;

            float roll = Random.Range(1, odds);
            //Debug.Log("roll: " + roll.ToString());

            if (roll == 50)
            {
                CreateTask();
            }
        }
        else
        {
            if (task.currState == Task.state.active)
            {
                catEnvironment.displayCat = true;
            }

            if (picTaken)
            {
                OnTaskSatisfied();
            }
        }
    }

    void CreateTask()
    {
        Debug.Log("Adding camera task");

        picTaken = false;

        string prompt = prompts[Random.Range(0, prompts.Length)];

        task = new Task(prompt, taskLength, this);
        AddTaskToQueue(task);
    }
}
