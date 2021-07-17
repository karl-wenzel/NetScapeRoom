using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{

    [SerializeField]
    Text CodeText;
    string CodeTextValue = "";

    public string Solution;

    public MinigameController controller;

    public HoldsText Text;

    AudioSource audio;

    public MinigameAudio minigameAudio;

    public AudioClip ClickDigit;
    public AudioClip ClickCheck;


    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        CodeText.text = CodeTextValue;
    }

    public void AddDigit(string d)
    {
        if (CodeTextValue.Length >= 4) return;

        CodeTextValue += d;

        if (ClickDigit != null) audio.PlayOneShot(ClickDigit);
    }

    private void DisplayWrong()
    {
        CodeText.color = Color.red;
        CodeTextValue = "FALSCH";

        minigameAudio.PlayAnswerWrong();

        Invoke("Reset", 2);
    }

    private void Reset()
    {
        CodeText.color = Color.green;
        CodeTextValue = "";
    }

    private void DisplayRight()
    {
        CodeText.color = Color.green;
        CodeTextValue = "RICHTIG";

        minigameAudio.PlayAnswerRight();

        controller.SuccessfulMinigame();
    }


    public void Check()
    {
        if (CodeTextValue == Solution)
            DisplayRight();
        else
            DisplayWrong();
    }
}
