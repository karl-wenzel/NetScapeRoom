using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public bool On = false;

    private LeverAudio audio;

    public void Start()
    {
        audio = GetComponent<LeverAudio>();

        UpdateLever();

    }

    public void Update()
    {

    }


    public void UpdateLever()
    {
        Vector3 size = transform.localScale;

        if (On) size.y = -Mathf.Abs(size.y);
        else size.y = Mathf.Abs(size.y);

        transform.localScale = size;

    }

    private void PlayClick()
    {
        if (On) audio.PlayClickOn();
        else audio.PlayClickOff();
    }

    public void Toogle()
    {
        On = !On;

        UpdateLever();
        PlayClick();
    }

    public void TurnOn()
    {
        On = true;
        UpdateLever();
    }

    public void TurnOff()
    {
        On = false;
        UpdateLever();
    }

    public bool Check()
    {
        return On;
    }


}
