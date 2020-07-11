using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalDiagnosisModule : MonoBehaviour, TimoModule
{
    public bool taskInQueue = false;
    public Task t;
    public float taskLength = 5.0f;

    public TextMesh text;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!taskInQueue)
        {
            
        }
    }

    public void AddTaskToQueue(Task t)
    {
        TaskManager.Instance.AddTask(t);
    }

    public void OnTaskSatisfied()
    {
        t.completed = true;
        taskInQueue = false;
    }
}
