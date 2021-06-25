using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public Vector3 RotationClosed;
    public Vector3 RotationOpen;

    public float RotationSpeed;

    private Vector3 CurrentRotationTarget;
    private bool IsOpen = false;


    public void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CurrentRotationTarget), Time.deltaTime * RotationSpeed);
    }

    public void OpenDoor()
    {
        IsOpen = true;
        CurrentRotationTarget = RotationOpen;
    }


    public void CloseDoor()
    {
        IsOpen = false;
        CurrentRotationTarget = RotationClosed;
    }

    public void OnCollisionEnter(Collision c)
    {
        Debug.Log("Open Door");
        OpenDoor();
    }
}
