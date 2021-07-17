using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameAudio : MonoBehaviour
{
    public AudioClip AnswerRight;
    public AudioClip AnswerWrong;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayAnswerRight()
    {
        if(AnswerRight != null) audio.PlayOneShot(AnswerRight);
    }

    public void PlayAnswerWrong()
    {
        if (AnswerWrong != null) audio.PlayOneShot(AnswerWrong);
    }

}
