using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAudio : MonoBehaviour
{
    [Range(0, 1)]
    public float Volume;

    public AudioClip[] PickUp;
    public AudioClip[] Drop;
    public AudioClip[] Insert;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Volume;
    }

    public void PlayPickUp()
    {
        if (PickUp.Length == 0) return;
        int randomClip = Random.Range(0, PickUp.Length);

        audioSource.PlayOneShot(PickUp[randomClip]);

    }

    public void PlayDrop()
    {
        if (Drop.Length == 0) return;

        int randomClip = Random.Range(0, Drop.Length);

        audioSource.PlayOneShot(Drop[randomClip]);
    }

    public void PlayInsert()
    {
        if (Insert.Length == 0) return;

        int randomClip = Random.Range(0, Insert.Length);

        audioSource.PlayOneShot(Insert[randomClip]);
    }
}
