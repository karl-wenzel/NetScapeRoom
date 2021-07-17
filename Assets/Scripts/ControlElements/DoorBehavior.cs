using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public AudioClip DoorOpen;

    private AudioSource audio;

    private Animator animator;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }


    public void OpenDoor()
    {
        Invoke("LevelComplete", 3);
        PlayerTimerController.me.StopTime();
        animator.SetBool("Open", true);
        audio.PlayOneShot(DoorOpen);
    }

    private void LevelComplete()
    {
        levelCompleted.me.LevelComplete();
    }
}
