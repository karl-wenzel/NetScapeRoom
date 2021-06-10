using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [Header("Add Controller Objects here")]

    [Tooltip("Sends 'StartMinigame' 'FailedMinigame' 'SuccessfulMinigame' and 'QuitMinigame'")]
    public GameObject[] NotifyMe;
    bool AlreadyQuit;

    [Space]
    [Header("↓ reference, dont change ↓")]
    public MinigameWindow window;
    [HideInInspector]
    public GameObject MinigameSource; //this is the object which requested this minigame

    void Start()
    {
        StartMinigame();
    }

    public void StartMinigame() {
        foreach (GameObject NotifyObj in NotifyMe)
        {
            NotifyObj.SendMessage("StartMinigame", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void FailedMinigame() {
        foreach (GameObject NotifyObj in NotifyMe)
        {
            NotifyObj.SendMessage("FailedMinigame", SendMessageOptions.DontRequireReceiver);
        }
        MinigameSource.SendMessage("FailedMinigame", SendMessageOptions.DontRequireReceiver);
        QuitMinigame();
    }

    public void SuccessfulMinigame()
    {
        foreach (GameObject NotifyObj in NotifyMe)
        {
            NotifyObj.SendMessage("SuccessfulMinigame", SendMessageOptions.DontRequireReceiver);
        }
        MinigameSource.SendMessage("SuccessfulMinigame", SendMessageOptions.DontRequireReceiver);
        QuitMinigame();
    }

    public void QuitMinigame() {
        if (AlreadyQuit) return;
        AlreadyQuit = true;
        foreach (GameObject NotifyObj in NotifyMe)
        {
            NotifyObj.SendMessage("QuitMinigame", SendMessageOptions.DontRequireReceiver);
        }
        MinigameSource.SendMessage("QuitMinigame", SendMessageOptions.DontRequireReceiver);
        window.Quit();
    }
}
