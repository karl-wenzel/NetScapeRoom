using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEventManager2 : MonoBehaviour
{
    public DoorBehavior ExitDoor;
    public DoorLockBehavior ExitDoorLock;

    public RoomComplete Complete;

    public Pulsating[] TutorialItems;
    private int CurrentItemFocus = 0;

    private bool DoorAlreadyOpen = false;

    public static int NumRoomsCompleted = 0;




    void Start()
    {
        TutorialItems[0].enabled = true;
    }

    public void UpdatePulsatingItems(int next)
    {
        TutorialItems[CurrentItemFocus].enabled = false;
        CurrentItemFocus = next;

        if (CurrentItemFocus < TutorialItems.Length) TutorialItems[CurrentItemFocus].enabled = true;
    }

    void Update()
    {
        if (ExitDoorLock.IsUnlocked() && !DoorAlreadyOpen)
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
