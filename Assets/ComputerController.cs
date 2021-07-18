using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public ClickableObject[] EnableClickable;

    private ItemSlotManager ItemSlot;
    private ClickableObject MinigameStarter;

    public bool HasUsb = false;

    private bool AlreadyCompletedMinigame = false;
    private bool MinigameRunning = false;

    void Start()
    {
        ItemSlot = GetComponent<ItemSlotManager>();
        MinigameStarter = GetComponent<ClickableObject>();
    }

    private void Update()
    {
        if (!ItemSlot.CheckIfEmpty() && ! MinigameRunning)
        {
            HasUsb = true;
            Invoke("StartMinigame", 1);
        }

    }

    public void StartMinigame()
    {
        if (!HasUsb || AlreadyCompletedMinigame) return;
        MinigameStarter.Clicked();
        MinigameRunning = true;
    }

    // Update is called once per frame
    public void SuccessfulMinigame()
    {
        AlreadyCompletedMinigame = true;

        foreach (ClickableObject item in EnableClickable)
        {
            item.Activate();
        }
    }
}
