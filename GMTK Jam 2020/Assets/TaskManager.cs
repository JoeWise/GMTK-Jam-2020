using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class TaskManager : Singleton<TaskManager>
{
    public Queue<Task> task_q;

    public Task[] currentTasks;
    public TextMesh[] taskTexts;

    // Start is called before the first frame update
    void Start()
    {
        task_q = new Queue<Task>();
        currentTasks = new Task[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTasks[0] == null && task_q.Count > 0)
        {
            Debug.Log("Adding Task 1");
            currentTasks[0] = task_q.Dequeue();
            taskTexts[0].text = currentTasks[0].prompt;
        }

        if (currentTasks[1] == null && task_q.Count > 0)
        {
            Debug.Log("Adding Task 2");
            currentTasks[1] = task_q.Dequeue();
            taskTexts[1].text = currentTasks[1].prompt;
        }

        if (currentTasks[2] == null && task_q.Count > 0)
        {
            Debug.Log("Adding Task 3");
            currentTasks[2] = task_q.Dequeue();
            taskTexts[2].text = currentTasks[2].prompt;
        }

        for(int i = 0; i < 3; i++)
        {
            if(currentTasks[i] != null && currentTasks[i].completed)
            {
                currentTasks[i].originatingModule.SetTaskInQueue(false);

                currentTasks[i] = null;
                taskTexts[i].text = "";
            }
        }

    }

    public void AddTask(Task t)
    {
        task_q.Enqueue(t);
    }

}

public class Task
{
    public string prompt;
    public float length;
    public TimoModuleBase originatingModule;
    public bool completed;

    public Task (string prompt, float length, TimoModuleBase originatingModule)
    {
        this.prompt = prompt;
        this.length = length;
        this.originatingModule = originatingModule;
    }
}