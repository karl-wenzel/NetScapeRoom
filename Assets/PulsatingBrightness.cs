using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PulsatingBrightness : MonoBehaviour
{
    public float MinBrightness = 0;
    public float MaxBrightness = 1;
    public float Frequency = 1;

    public bool IsLight = false;

    private SpriteRenderer spriteRenderer;
    private Color OriginalColor;
    private Light2D Light;


    private void Start()
    {
        if (!IsLight)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            OriginalColor = spriteRenderer.color;
        }
        else
        {
            Light = GetComponent<Light2D>();
            OriginalColor = Light.color;
        }

    }

    void Update()
    {
        float currentBrightness = MinBrightness + 
                                  (Mathf.Sin(Time.time * Frequency * Mathf.PI * 2) + 1) / 2 * 
                                  (MaxBrightness - MinBrightness);

        if(!IsLight)
            spriteRenderer.color = OriginalColor * currentBrightness;
        else
            Light.color = OriginalColor * currentBrightness;
    }
}
