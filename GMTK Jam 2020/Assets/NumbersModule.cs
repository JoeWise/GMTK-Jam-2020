using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersModule : TimoModuleBase
{
    [System.Serializable]
    public struct PromptAnswer
    {
        public string prompt;
        public string answer;
    }

    public PromptAnswer[] promptsAndAnswers;

    public PromptAnswer curr;

    public string lastNumber = "";

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
            float roll = Random.Range(1, odds);
            //Debug.Log("roll: " + roll.ToString());

            if (roll == 50)
            {
                CreateTask();
            }
        }
        else
        {
            if(lastNumber == curr.answer)
            {
                OnTaskSatisfied();
                lastNumber = "";
            }
        }
    }

    void CreateTask()
    {
        Debug.Log("Adding number task");

        curr = promptsAndAnswers[Random.Range(0, promptsAndAnswers.Length)];

        task = new Task(curr.prompt, taskLength, this);
        AddTaskToQueue(task);
    }

    public void SetLastNumber(string n)
    {
        lastNumber = n;
    }
}