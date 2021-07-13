using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class IndicatorLight : MonoBehaviour
{
    public Color ColorOff;
    public Color ColorOn;

    public Light2D light;

    public bool On = false;

    private SpriteRenderer spriteRenderer;




    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateLight()
    {
        if (On)
        {
            spriteRenderer.color = ColorOn;
            light.color = ColorOn;
        }
        else
        {
            spriteRenderer.color = ColorOff;
            light.color = ColorOff;
        }
    }


    public void TurnOn()
    {
        On = true;
        UpdateLight();
    }

    public void TurnOff()
    {
        On = false;
        UpdateLight();
    }
}
