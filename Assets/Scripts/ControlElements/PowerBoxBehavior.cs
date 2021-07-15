using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxBehavior : MonoBehaviour
{
    public ItemSlotManager[] Itemslots;
    public Lever Lever;
    public IndicatorLight m_light;

    private bool IsOn = false;

    public AudioClip FailedLever;
    private AudioSource m_audio;

    public void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void Update()
    {


        if (Lever.Check() && CheckFuses())
        {
            m_light.TurnOn();
            IsOn = true;
        }
        else if(Lever.Check())
        {
            IsOn = false;
            Lever.TurnOff();
            m_light.TurnOff();
            PlayFail();
        }

    }

    public bool HasPower()
    {
        return IsOn;
    }

   private void PlayFail()
    {
        m_audio.PlayOneShot(FailedLever);
    }


    bool CheckFuses()
    {
        bool valid = true;

        for(int i=0; i<Itemslots.Length; i++)
        {
            if (Itemslots[i].CheckIfEmpty()) return false;
        }

        return valid;
    }
}
