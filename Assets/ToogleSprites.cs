using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleSprites : MonoBehaviour
{
    public Sprite spriteOn;
    public Sprite SpriteOff;

    public SpriteRenderer spriteRenderer;


    private bool On;

    public void Toogle()
    {
        On = !On;

        if (On) spriteRenderer.sprite = spriteOn;
        else spriteRenderer.sprite = SpriteOff;
    }

    public void SetOn()
    {
        On = true;
        spriteRenderer.sprite = spriteOn;
    }

    public void SetOff()
    {
        On = false;
        spriteRenderer.sprite = SpriteOff;
    }

}
