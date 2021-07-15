using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DeskLampController : MonoBehaviour
{
    public bool InitialState;

    public Sprite SpriteOn;
    public Sprite SpriteOff;

    public SpriteRenderer spriteRenderer;
    public Color LightColor;

    public Light2D light;

    private bool IsOn;
    private Color TargetColor;

    private LeverAudio audio;

    public void Start()
    {
        audio = GetComponent<LeverAudio>();

        IsOn = InitialState;
        UpdateSprite();
    }

    public void Update()
    {
        light.color = Color.Lerp(light.color, TargetColor, Time.deltaTime * 30);
    }

    public void UpdateSprite()
    {
        if (IsOn)
        {
            spriteRenderer.sprite = SpriteOn;
            TargetColor = LightColor;
        }
        else
        {
            spriteRenderer.sprite = SpriteOff;
            TargetColor = new Vector4(0f,0f,0f,1f);
        }
    }

    public void PlayClickSound()
    {
        if (IsOn) audio.PlayClickOn();
        else audio.PlayClickOff();

    }

    public void TurnOn()
    {
        IsOn = true;
        UpdateSprite();
        PlayClickSound();
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
        PlayClickSound();
    }

    public bool CheckIfOn()
    {
        return IsOn;
    }
}
