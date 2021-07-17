using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEventManager : MonoBehaviour
{

    public DoorBehavior ExitDoor;
    public DoorLockBehavior ExitDoorLock;
    public PowerBoxBehavior PowerBox;
    public ItemSlotManager Vitrine1;
    public ItemSlotManager Vitrine2;
    public ItemSlotManager Vitrine3;

    private bool DoorAlreadyOpen = false;




    void Start()
    {
        
    }

    void Update()
    {
        if (ExitDoorLock.IsUnlocked() && PowerBox.HasPower() && !DoorAlreadyOpen)
        {
            ExitDoor.OpenDoor();
            DoorAlreadyOpen = true;
        }
    }

    public void DoorUnlocked()
    {
    }
}
