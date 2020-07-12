using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimoModuleBase : MonoBehaviour
{
    public bool taskInQueue = false;
    public Task task;
    public float taskLength = 5.0f;
    public Window window;
    public int odds = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTaskToQueue(Task t)
    {
        TaskManager.Instance.AddTask(t);
        taskInQueue = true;
    }

    public virtual void OnTaskSatisfied()
    {
        task.completed = true;
        window.CloseWindow();
    }


    public virtual void SetTaskInQueue(bool b)
    {
        taskInQueue = b;
    }
}
