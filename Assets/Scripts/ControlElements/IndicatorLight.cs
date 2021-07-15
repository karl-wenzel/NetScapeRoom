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

    Light2D m_light;

    public bool On = false;

    private SpriteRenderer spriteRenderer;




    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_light = GetComponentInChildren<Light2D>();
    }

    public void UpdateLight()
    {
        if (On)
        {
            spriteRenderer.sprite = SpriteOn;
            m_light.color = ColorOn;
            m_light.intensity = 20;
        }
        else
        {
            spriteRenderer.sprite = SpriteOff;
            m_light.color = ColorOff;
            m_light.intensity = 1;
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
