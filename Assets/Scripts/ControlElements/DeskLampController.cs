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

    private Light2D m_light;

    private bool IsOn;
    private Color TargetColor;

    private LeverAudio m_audio;

    public void Start()
    {
        m_audio = GetComponent<LeverAudio>();
        m_light = GetComponentInChildren<Light2D>();

        IsOn = InitialState;
        UpdateSprite();
    }


    float StartedLerping = 0.0f;
    IEnumerator LerpLightColor() {
        while (StartedLerping + 1f > Time.time) {
            m_light.color = Color.Lerp(m_light.color, TargetColor, Time.deltaTime * 30);
            yield return null;
        }
        m_light.color = TargetColor;
    }

    public void UpdateSprite()
    {
        if (IsOn)
        {
            spriteRenderer.sprite = SpriteOn;
            TargetColor = LightColor;
            StartCoroutine(LerpLightColor());
        }
        else
        {
            spriteRenderer.sprite = SpriteOff;
            TargetColor = new Vector4(0f,0f,0f,1f);
            StartCoroutine(LerpLightColor());
        }
    }

    public void PlayClickSound()
    {
        if (IsOn) m_audio.PlayClickOn();
        else m_audio.PlayClickOff();

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
