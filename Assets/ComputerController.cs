using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public ClickableObject[] EnableClickable;

    private ItemSlotManager ItemSlot;
    private ClickableObject MinigameStarter;

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
            Invoke("StartMinigame", 1);
            MinigameRunning = true;
        }

    }

    private void StartMinigame()
    {
        MinigameStarter.Clicked();
    }

    // Update is called once per frame
    public void SuccessfulMinigame()
    {

        foreach (ClickableObject item in EnableClickable)
        {
            item.Activate();
        }
    }
}
