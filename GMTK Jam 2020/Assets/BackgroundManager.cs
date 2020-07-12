using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Color[] colors;
    public SpriteRenderer sr;

    int prev_f = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int f = TaskManager.Instance.failed;

        if(f != prev_f && f < colors.Length)
        {
            sr.color = colors[f];
        }
        
        prev_f = f;
    }
}
