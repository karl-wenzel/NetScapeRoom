using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ToogleLight : MonoBehaviour
{
    public Color ColorOn;
    public Color ColorOff;

    public Light2D light;


    private bool On;

    public void Toogle()
    {
        On = !On;

        if (On) light.color = ColorOn;
        else light.color = ColorOff;
    }

    public void SetOn()
    {
        On = true;
        light.color = ColorOn;
    }

    public void SetOff()
    {
        On = false;
        light.color = ColorOff;
    }

}
