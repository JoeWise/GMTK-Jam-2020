using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MedicalModule : TimoModuleBase
{
    public string[] prompts;

    public Sprite[] skinConditions;

    public GameObject[] sprites;

    public SpriteRenderer[] spriteRenderers;

    public GameObject choosing;
    public GameObject results;

    public GameObject notFound;

    public string[] resultsStrings;

    int curr;
    int answer;

    List<int> choiceNumbers;
    int[] randomChoiceNumbers;

    List<int> conditionNumbers;
    int[] randomConditionNumbers;

    public int guess = -1;

    public Task.state prevState = Task.state.waiting;

    private void OnEnable()
    {
        CreateTask();

        guess = -1;
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
            notFound.SetActive(true);

            int roll = Random.Range(1, odds);
            //Debug.Log("roll: " + roll.ToString());

            if (roll == 50)
            {
                StopAllCoroutines();
                choosing.SetActive(true);
                results.SetActive(false);

                CreateTask();
            }
        }
        else
        {
            if(task.currState == Task.state.active)
            {
                notFound.SetActive(false);
            }
            
            if (task.currState == Task.state.active)
            {
                foreach (SpriteRenderer sr in spriteRenderers)
                {
                    //Debug.Log("sprites true");
                    sr.enabled = true;
                }
            }

            if(guess == answer)
            {
                OnTaskSatisfied();
            }

            prevState = task.currState;
        }
    }

    void CreateTask()
    {
        Debug.Log("Adding medical task");

        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.enabled = false;
        }


        GenerateRandomNumbers();

        // pick an example sprite from the list of all conditions
        curr = randomConditionNumbers[0];

        // set the example sprite
        spriteRenderers[0].sprite = skinConditions[curr];

        // save the answer
        answer = randomChoiceNumbers[0];
        // set answer sprite to correct sprite
        spriteRenderers[answer].sprite = skinConditions[curr];

        // set other choices sprite to random conditions
        spriteRenderers[randomChoiceNumbers[1]].sprite = skinConditions[randomConditionNumbers[1]];
        spriteRenderers[randomChoiceNumbers[2]].sprite = skinConditions[randomConditionNumbers[2]];

        guess = -1;

        foreach (GameObject g in sprites)
        {
            float x = g.transform.rotation.eulerAngles.x;
            float y = g.transform.rotation.eulerAngles.y;
            float z = Random.Range(1, 360);

            //g.transform.rotation.eulerAngles.Set(x, y, z);
            g.transform.Rotate(g.transform.forward, z);
        }

        string prompt = prompts[Random.Range(0, prompts.Length)];

        task = new Task(prompt, taskLength, this);
        AddTaskToQueue(task);
    }

    void GenerateRandomNumbers()
    {
        choiceNumbers = new List<int>(3);
        for (int i = 1; i <= 3; i++)
        {
            choiceNumbers.Add(i);
        }

        randomChoiceNumbers = new int[3];
        for (int i = 0; i < randomChoiceNumbers.Length; i++)
        {
            int thisNumber = Random.Range(0, choiceNumbers.Count);
            randomChoiceNumbers[i] = choiceNumbers[thisNumber];
            choiceNumbers.RemoveAt(thisNumber);
        }


        conditionNumbers = new List<int>(skinConditions.Length);
        for (int i = 0; i < skinConditions.Length; i++)
        {
            conditionNumbers.Add(i);
        }

        randomConditionNumbers = new int[3];
        for (int i = 0; i < randomConditionNumbers.Length; i++)
        {
            int thisNumber = Random.Range(0, conditionNumbers.Count);
            randomConditionNumbers[i] = conditionNumbers[thisNumber];
            conditionNumbers.RemoveAt(thisNumber);
        }
    }

    public void Guess(int g)
    {
        guess = g;
    }

    public override void OnTaskSatisfied()
    {
        task.completed = true;
        StartCoroutine("DisplayResults");
    }

    public override void SetTaskInQueue(bool b)
    {
        //Debug.Log("set task in queue");
        taskInQueue = b;

        if(!taskInQueue)
        {
            foreach (SpriteRenderer sr in spriteRenderers)
            {
                //Debug.Log("sprites false");
                sr.enabled = false;
            }

        }
    }


    IEnumerator DisplayResults()
    {
        Debug.Log("inside coroutine");

        choosing.SetActive(false);

        TextMeshPro r = results.GetComponentInChildren<TextMeshPro>();

        r.text = resultsStrings[Random.Range(0, resultsStrings.Length)];

        results.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        results.SetActive(false);
        choosing.SetActive(true);

        window.CloseWindow();

        yield return null;
    }
}
