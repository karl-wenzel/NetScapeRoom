using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxBehavior : MonoBehaviour
{
    public ItemSlotManager[] Itemslots;
    public Lever Lever;
    public IndicatorLight m_light;

    public ParticleSystem[] particleSystem;

    private bool IsOn = false;

    private bool AlreadyPlayed = false;

    public AudioClip FailedLever;
    public AudioClip TurnOn;
    private AudioSource m_audio;

    public void Start()
    {
        DisableSparks();
        m_audio = GetComponent<AudioSource>();
    }

    public void Update()
    {


        if (Lever.Check() && CheckFuses())
        {
            if (!AlreadyPlayed)
            {
                m_audio.PlayOneShot(TurnOn);
                AlreadyPlayed = true;
            }
            m_light.TurnOn();
            IsOn = true;
        }
        else if(Lever.Check())
        {
            EnableSparks();
            Invoke("DisableSparks", 1);
            IsOn = false;
            Lever.TurnOff();
            m_light.TurnOff();
            PlayFail();
        }

    }

    private void EnableSparks()
    {
        foreach(ParticleSystem sparks in particleSystem)
        {
            sparks.Play();
        }
    }

    private void DisableSparks()
    {
        foreach (ParticleSystem sparks in particleSystem)
        {
            sparks.Stop();
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
