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




    void Start()
    {
        
    }

    void Update()
    {
        if (ExitDoorLock.IsUnlocked() && PowerBox.HasPower())
        {
            ExitDoor.OpenDoor();
        }
    }

    public void DoorUnlocked()
    {
    }
}
