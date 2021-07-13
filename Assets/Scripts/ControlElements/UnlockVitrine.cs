using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockVitrine : MonoBehaviour
{
    public ItemSlotManager ItemSlot;

    public void SuccessfulMinigame()
    {
        ItemSlot.UnlockItem();
    }
}
