using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLampController : MonoBehaviour
{
    public bool InitialState;

    public Sprite SpriteOn;
    public Sprite SpriteOff;
    public SpriteRenderer spriteRenderer;

    private bool IsOn;

    public void Start()
    {
        IsOn = InitialState;
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        if (IsOn) spriteRenderer.sprite = SpriteOn;
        else spriteRenderer.sprite = SpriteOff;
    }

    public void TurnOn()
    {
        IsOn = true;
        UpdateSprite();
    }

    public void TurnOff()
    {
        IsOn = false;
        UpdateSprite();
    }

    public void Toogle()
    {
        IsOn = !IsOn;
        UpdateSprite();
    }

    public bool CheckIfOn()
    {
        return IsOn;
    }
}
