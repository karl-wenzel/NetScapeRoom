using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class IndicatorLight : MonoBehaviour
{
    public Color ColorOff;
    public Color ColorOn;

    public Sprite SpriteOff;
    public Sprite SpriteOn;

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
            spriteRenderer.sprite = SpriteOn;
            light.color = ColorOn;
            light.intensity = 20;
        }
        else
        {
            spriteRenderer.sprite = SpriteOff;
            light.color = ColorOff;
            light.intensity = 1;
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
