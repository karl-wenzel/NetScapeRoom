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

    public RoomComplete Complete;

    private bool DoorAlreadyOpen = false;

    public static int NumRoomsCompleted = 0;




    void Start()
    {
        
    }

    void Update()
    {
        if (ExitDoorLock.IsUnlocked() && PowerBox.HasPower() && !DoorAlreadyOpen)
        {
            ExitDoor.OpenDoor();
            DoorAlreadyOpen = true;
            Invoke("RoomComplete", 4);
        }
    }

    private void RoomComplete()
    {
        NumRoomsCompleted++;
        PlayerPrefs.SetInt("NumRoomsCompleted", NumRoomsCompleted);
        Complete.SpawnNextButton();
    }
}
