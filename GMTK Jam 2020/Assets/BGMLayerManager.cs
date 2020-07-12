using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMLayerManager : MonoBehaviour
{
    public int audioState;

    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        audioState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        audioState = TaskManager.Instance.failed;
        switch (audioState)
        {
            case 0:
                mixer.SetFloat("AmbVol", 0);
                mixer.SetFloat("L1Vol", -80);
                mixer.SetFloat("RadioVol", -80);
                mixer.SetFloat("FinalVol", -80);

                break;
            case 1:
                mixer.SetFloat("AmbVol", 0);
                mixer.SetFloat("L1Vol", 0);
                mixer.SetFloat("RadioVol", -80);
                mixer.SetFloat("FinalVol", -80);

                break;
            case 2:
                mixer.SetFloat("AmbVol", 0);
                mixer.SetFloat("L1Vol", 0);
                mixer.SetFloat("RadioVol", -30);
                mixer.SetFloat("FinalVol", -80);

                break;
            case 3:
                mixer.SetFloat("AmbVol", 0);
                mixer.SetFloat("L1Vol", 0);
                mixer.SetFloat("RadioVol", 0);
                mixer.SetFloat("FinalVol", -80);

                break;

            case 4:
                mixer.SetFloat("AmbVol", 0);
                mixer.SetFloat("L1Vol", 0);
                mixer.SetFloat("RadioVol", 0);
                mixer.SetFloat("FinalVol", 0);

                break;
            case 5:
                mixer.SetFloat("AmbVol", -80);
                mixer.SetFloat("L1Vol", -80);
                mixer.SetFloat("RadioVol", -10);
                mixer.SetFloat("FinalVol", -80);
                break;

        }
    }
}
