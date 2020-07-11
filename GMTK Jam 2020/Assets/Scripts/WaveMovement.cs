using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveMovement : MonoBehaviour
{
    public float control = 100;
    public float drainSpeed = 50;
    public float fillSpeed = 25;
    public Slider controlBar;

    public float fallSpeed;

    public float amplitude = 1;
    public float period = 0.5f;
    public float phase = 1;

    private float frequency = 1;
    private float angularFrequency = 1;
    private float elapsedTime = 0;

    public bool triangle;
    public bool square;
    public bool sine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;

        if (sine)
        {
            x = SmoothSineWave();
        }
        else if(square)
        {
            x = SquareWave();
        }
        else if (triangle)
        {
            x = TriangleWave();
        }

        if (float.IsNaN(x))
        {
            x = this.transform.localPosition.x;
        }

        float y = this.transform.localPosition.y + (fallSpeed * Time.deltaTime);

        this.transform.localPosition = new Vector3(x, y, this.transform.localPosition.z);


    }

    private float SquareWave()
    {
        return Mathf.Sign(SmoothSineWave()) * amplitude;
    }

    public float TriangleWave()
    {

        float x = SmoothSineWave();

        return (Mathf.Abs((x % 4) - 2) - 1) * amplitude;
    }

    private float SmoothSineWave()
    {
        // y(t) = A * sin(ωt + θ) [Basic Sine Wave Equation]
        // [A = amplitude | ω = AngularFrequency ((2*PI)f) | f = 1/T | T = [period (s)] | θ = phase | t = elapsedTime]
        // Public/Serialized Variables: amplitude, period, phase
        // Private/Non-serialized Variables: frequency, angularFrequency, elapsedTime
        // Local Variables: omegaProduct, y


        // If the value of period has altered last known frequency...
        if (1 / (period) != frequency)
        {
            // Recalculate frequency & omega.
            frequency = 1 / (period);
            angularFrequency = (2 * Mathf.PI) * frequency;
        }

        // Update elapsed time.
        if (!Input.GetKey(KeyCode.E))
        {
            elapsedTime += Time.deltaTime;
            control += fillSpeed * Time.deltaTime;
        }
        else if(control > 0)
        {
            control -= drainSpeed * Time.deltaTime;
        }

        control = Mathf.Clamp(control, 0, 100);
        controlBar.value = control / 100;

        // Calculate new omega-time product.
        float omegaProduct = (angularFrequency * elapsedTime);
        
        // Plug in all calculated variables into the complete Sine wave equation.
        float x = (amplitude * Mathf.Sin(omegaProduct + phase));

        return x;
    }

}
