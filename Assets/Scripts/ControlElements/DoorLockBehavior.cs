using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockBehavior : MonoBehaviour
{

    public Draggable Accepts;

    public ItemSlotManager ItemSlot;

    //private bool Unlocked = false;


    public bool IsUnlocked()
    {
        return !ItemSlot.CheckIfEmpty();
    }
}
