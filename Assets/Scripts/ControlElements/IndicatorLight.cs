using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorLight : MonoBehaviour
{
    public Color ColorOff;
    public Color ColorOn;

    public bool On = false;

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void TurnOn()
    {
        On = true;
        spriteRenderer.color = ColorOn;
    }

    public void TurnOff()
    {
        On = false;
        spriteRenderer.color = ColorOff;
    }
}
