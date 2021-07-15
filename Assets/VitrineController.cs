using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitrineController : MonoBehaviour
{
    public bool Locked;

    public GameObject Glass;

    public  ItemSlotManager ItemSlot;



    public void Unlock()
    {
        Locked = false;
        ItemSlot.UnlockItem();
        ItemSlot.RemoveItem();
        Destroy(Glass);
    }
}
