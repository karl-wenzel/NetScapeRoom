using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnLightOn : MonoBehaviour
{
    public SpriteRenderer Light;

    public void SuccessfulMinigame() {
        Light.color = Color.white;
    }
}
