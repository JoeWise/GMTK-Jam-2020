using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimoModuleBase : MonoBehaviour
{
    public bool taskInQueue = false;
    public Task task;
    public float taskLength = 5.0f;
    public GameObject window;

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

    public void OnTaskSatisfied()
    {
        task.completed = true;
        window.SetActive(false);
    }

    public void SetTaskInQueue(bool b)
    {
        taskInQueue = b;
    }
}
