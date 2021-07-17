using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLeverValue : MonoBehaviour
{
    public MinigameController controller;
    public Slider slider;

    public MinigameAudio audio;

    public void CheckValue() {
        if (slider.value == 1f) {
            audio.PlayAnswerRight();

            controller.SuccessfulMinigame();
        }
    }
}
