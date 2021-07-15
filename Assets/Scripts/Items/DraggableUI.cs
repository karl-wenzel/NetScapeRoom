using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableUI : MonoBehaviour
{
    public float DragSpeed = 10;


    private Vector3 TargetPosition;

    public void Start()
    {
        TargetPosition = transform.position;
    }

    public void Update()
    {
            transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * DragSpeed);
    }

    public void BeginDrag()
    {
        TargetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void Drag()
    {
        TargetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void EndDrag()
    {
    }


}
