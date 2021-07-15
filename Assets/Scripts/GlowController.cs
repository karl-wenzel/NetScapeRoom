using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlowController : MonoBehaviour
{
    public float GlowFadeOutSpeed;

    public DeskLampController lamp;

    private float GlowIntensity = 1f;

    private Light2D m_light;

    private bool Trigger = false;


    public void ResetGlowIntensity()
    {
        GlowIntensity = 1f;
    }

    public void Start()
    {
        m_light = GetComponent<Light2D>();
    }


    void Update()
    {
        if (lamp.CheckIfOn())
        {
            GlowIntensity = 0f;
            Trigger = false;
        }
        else
        {
            if (Trigger == false)
            {
                Trigger = true;
                ResetGlowIntensity();
            }

            if (GlowIntensity > 0) GlowIntensity -= Time.deltaTime * GlowFadeOutSpeed;
        }


        m_light.intensity = GlowIntensity;
    }
}
