using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTimer : MonoBehaviour
{
    public GameObject[] segments;

    public int curr = 10;

    public bool countdown = false;

    public float rate = 1.0f;

    public float elapsedTime = 0;

    public bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= rate)
            {
                DecrementTimer();
                elapsedTime = 0;

                if(curr == 0)
                {
                    finished = true;
                    countdown = false;
                }
            }
        }
    }

    public void StartCountdown(float length)
    {
        rate = length / 10.0f;
        countdown = true;
    }


    public void DecrementTimer()
    {
        if(curr > 0)
        {
            segments[curr - 1].SetActive(false);

            curr -= 1;
        }
    }

    public void ResetTimer()
    {
        for(int i = 0; i < 10; i++)
        {
            segments[i].SetActive(true);
        }

        curr = 10;
        elapsedTime = 0;
        finished = false;

    }
}
