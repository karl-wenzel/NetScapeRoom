using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public ClickableObject[] EnableClickable;

    private ItemSlotManager ItemSlot;
    private ClickableObject MinigameStarter;
    public GameEventStartMinigame Minigame;

    [Header("Inspector")]
    public ClickableObject Clickable;
    public GameEventStartMinigame inspector;

    [TextArea]
    public string Description;

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

    public void StartDialoge()
    {
        inspector.MinigamePrefab.GetComponent<HoldsText>().SetDescription(Description);
        Clickable.AddMinigame(inspector);
        Clickable.Clicked();
    }

    public void StartMinigame()
    {
        if (AlreadyCompletedMinigame) return;
        if (!HasUsb)
        {
            StartDialoge();
            return;
        }
        MinigameStarter.AddMinigame(Minigame);
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
