using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    public string curr;
    public TextMeshPro textField;
    public NumbersModule numbersModule;

    // Start is called before the first frame update
    void Start()
    {
        textField.text = "";
        textField.text = curr.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterNumber(int n)
    {
        if(curr.Length < 5)
        {
            curr += n;
            textField.text = curr;
        }
    }

    public void SendNumber()
    {
        numbersModule.SetLastNumber(curr);

        curr = "";
        textField.text = curr;
    }
}
