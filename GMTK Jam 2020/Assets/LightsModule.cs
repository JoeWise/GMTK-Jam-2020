using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsModule : TimoModuleBase
{
    public LightSwitch[] switches;

    LightSwitch curr;
    string goalState;

    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.Log("Adding lights task");

                curr = switches[Random.Range(0, switches.Length)];

                
                if(curr.on)
                {
                    goalState = "off";
                }
                else
                {
                    goalState = "on";
                }

                string prompt = "Timo, turn " + curr.GetLabel() + " light " + goalState;

                task = new Task(prompt, 10.0f, this);
                AddTaskToQueue(task);
            }
        }
        else
        {
            if(goalState == "on" && curr.on)
            {
                OnTaskSatisfied();
            }
            else if(goalState == "off" && !curr.on)
            {
                OnTaskSatisfied();
            }
        }
    }
}
