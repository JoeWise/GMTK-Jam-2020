using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseShieldModule : TimoModuleBase
{
    public TextMesh text;
    public bool shieldUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!taskInQueue)
        {
            float roll = Random.Range(1, 1000);
            //Debug.Log("roll: " + roll.ToString());

            if (roll == 50)
            {
                Debug.Log("Adding shield task");

                string prompt;

                if (shieldUp)
                {
                   prompt  = "Lower Shield";
                }
                else
                {
                    prompt = "Raise Shield";
                }

                task = new Task(prompt, 10.0f, this);
                AddTaskToQueue(task);

                taskInQueue = true;
            }
        }
    }

    public void ToggleShield()
    {
        Debug.Log("Toggle shield");

        if (taskInQueue)
        {
            shieldUp = !shieldUp;
            OnTaskSatisfied();

            if(shieldUp)
            {
                text.text = "Lower";
            }
            else
            {
                text.text = "Raise";
            }
        }
    }
}
