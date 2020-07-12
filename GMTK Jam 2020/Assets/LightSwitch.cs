using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public bool on = true;
    public Sprite onSprite;
    public Sprite offSprite;

    public string label;
    SpriteRenderer spriteRenderer;

    private void Reset()
    {
        label = this.GetComponentInChildren<TextMeshPro>().text;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetLabel()
    {
        return label;
    }

    public void toggleSwitch()
    {
        if (on)
        {
            turnOff();
        }
        else
        {
            turnOn();
        }
    }

    public void turnOn()
    {
        on = true;
        spriteRenderer.sprite = onSprite;
    }

    public void turnOff()
    {
        on = false;
        spriteRenderer.sprite = offSprite;
    }
}
