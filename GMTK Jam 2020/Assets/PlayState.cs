using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class PlayState : State
{
    public GameObject[] modules;

    List<int> nums;

    float elapsedTime;
    
    private void OnEnable()
    {
        TaskManager.Instance.ResetValues();
        
        nums = new List<int>(modules.Length);

        for(int i = 0; i < modules.Length; i++)
        {
            nums.Add(i);
        }

        foreach(GameObject g in modules)
        {
            g.SetActive(false);
        }
        
        elapsedTime = 0.0f;

        // Enable a random module to start
        int index = Random.Range(0, nums.Count);

        modules[nums[index]].SetActive(true);

        nums.RemoveAt(index);
    }

    private void OnDisable()
    {
        foreach (GameObject g in modules)
        {
            g.SetActive(false);
        }

        TaskManager.Instance.ClearTasks();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nums.Count > 0)
        {
            elapsedTime += Time.deltaTime;
            
            if(elapsedTime >= 10.0f)
            {
                int index = Random.Range(0, nums.Count);

                modules[nums[index]].SetActive(true);

                nums.RemoveAt(index);

                elapsedTime = 0.0f;
            }
        }

        if(TaskManager.Instance.failed >= 5)
        {
            Next();
        }
    }
}
