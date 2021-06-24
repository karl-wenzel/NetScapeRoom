using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLeverValue : MonoBehaviour
{
    public MinigameController controller;
    public Slider slider;

    public void CheckValue() {
        if (slider.value == 1f) {
            controller.SuccessfulMinigame();
        }
    }
}
