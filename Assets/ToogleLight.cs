using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ToogleLight : MonoBehaviour
{
    public Color ColorOn;
    public Color ColorOff;

    public Light2D m_light;


    private bool On;

    public void Toogle()
    {
        On = !On;

        if (On) m_light.color = ColorOn;
        else m_light.color = ColorOff;
    }

    public void SetOn()
    {
        On = true;
        m_light.color = ColorOn;
    }

    public void SetOff()
    {
        On = false;
        m_light.color = ColorOff;
    }

}
