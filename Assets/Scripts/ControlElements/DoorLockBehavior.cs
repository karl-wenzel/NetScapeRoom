using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockBehavior : MonoBehaviour
{
    public GameObject DoorReference;

    public Draggable Accepts;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (Accepts == collider.GetComponent<Draggable>())
        {
            DoorReference.GetComponent<DoorBehavior>().OpenDoor();
            Destroy(collider);
        }
    }
}
