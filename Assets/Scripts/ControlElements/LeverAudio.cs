using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAudio : MonoBehaviour
{
    [Range(0, 1)]
    public float Volume;

    public AudioClip[] ClickOn;
    public AudioClip[] ClickOff;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Volume;
    }

    public void PlayClickOn()
    {
        int randomClip = Random.Range(0, ClickOn.Length);

        audioSource.PlayOneShot(ClickOn[randomClip]);

    }

    public void PlayClickOff()
    {
        int randomClip = Random.Range(0, ClickOff.Length);

        audioSource.PlayOneShot(ClickOff[randomClip]);
    }


}
