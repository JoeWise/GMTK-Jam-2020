using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
    public CatEnvironment catEnvironment;
    public CameraModule cameraModule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryToTakePic()
    {
        if (catEnvironment.catVisible)
        {
            cameraModule.picTaken = true;
        }
    }
}
