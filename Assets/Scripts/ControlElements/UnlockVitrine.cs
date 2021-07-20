using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockVitrine : MonoBehaviour
{
    public VitrineController[] Vitrine;

    public void SuccessfulMinigame()
    {
        foreach (VitrineController controller in Vitrine)
        {
            controller.Unlock();
        }
    }
}
