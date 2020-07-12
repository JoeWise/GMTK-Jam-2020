using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using TMPro;

public class TaskManager : Singleton<TaskManager>
{
    public Queue<Task> task_q;

    public Task[] currentTasks;
    public TextMeshPro[] taskTexts;
    public TaskTimer[] taskTimers;
    public TextMeshPro score;
    public int completed = 0;
    public int best = 0;
    public int failed = 0;

    // Start is called before the first frame update
    void Start()
    {
        task_q = new Queue<Task>();
        currentTasks = new Task[3];

        completed = 0;
        failed = 0;

        updateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < currentTasks.Length; i++)
        {
            // check if there are any empty slots that we can fill
            if (currentTasks[i] == null && task_q.Count > 0)
            {
                Debug.Log("Adding Task " + i.ToString());
                currentTasks[i] = task_q.Dequeue();
                taskTexts[i].text = currentTasks[i].prompt;

                taskTimers[i].gameObject.SetActive(true);
                taskTimers[i].ResetTimer();
                taskTimers[i].StartCountdown(currentTasks[i].length);
            }

            // check if there are any filled slots that we can empty
            if (currentTasks[i] != null)
            {
                //if the task was completed successfully
                if(currentTasks[i].completed)
                {
                    //remove the task
                    currentTasks[i].originatingModule.SetTaskInQueue(false);

                    currentTasks[i] = null;
                    taskTexts[i].text = "";

                    //remove timer
                    taskTimers[i].gameObject.SetActive(false);

                    // increment score
                    completed += 1;

                    if (completed > best)
                    {
                        best = completed;
                    }

                    updateScoreText();
                }
                //if time ran out
                else if(taskTimers[i].finished)
                {
                    //remove the task
                    currentTasks[i].originatingModule.SetTaskInQueue(false);

                    currentTasks[i] = null;
                    taskTexts[i].text = "";

                    //remove timer
                    taskTimers[i].gameObject.SetActive(false);

                    //update fail count
                    failed += 1;
                    updateScoreText();
                    
                }
            }
        }
    }

    public void AddTask(Task t)
    {
        task_q.Enqueue(t);
    }

    public void updateScoreText()
    {
        string scoreText = "Completed: " + completed.ToString() + "\nBest: " + best.ToString() + "\nFailed: " + failed.ToString();

        score.text = scoreText;
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