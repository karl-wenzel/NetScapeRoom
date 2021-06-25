using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommodeBehavior : MonoBehaviour
{

    public Vector3 PositionOpen;
    public float SlideTime;

    public GameObject Slide;
    public GameObject ContainedItem;

    private Vector3 TargetPosition;
    private bool IsOpen = false;


    public void Start()
    {
        Slide.transform.localPosition = Vector3.zero;
        ContainedItem.transform.position = Slide.transform.position;

        ContainedItem.GetComponent<Draggable>().enabled = false;
        ContainedItem.GetComponent<BoxCollider2D>().enabled = false;
        ContainedItem.GetComponent<SpriteRenderer>().sortingLayerName = "ControlElements";
        ContainedItem.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void Update()
    {
    }

    public void ToogleOpen()
    {
        IsOpen = !IsOpen;

        if (IsOpen) Open();
        else Close();

    }

    public void Open()
    {
        Slide.transform.localPosition = PositionOpen;

        Draggable draggable = ContainedItem.GetComponent<Draggable>();
        draggable.enabled = true;
        draggable.SetPosition(Slide.transform.position);

        ContainedItem.GetComponent<BoxCollider2D>().enabled = true;
        ContainedItem.GetComponent<SpriteRenderer>().sortingLayerName = "Items";
        ContainedItem = null;
    }

    public void Close()
    {
        Slide.transform.localPosition = Vector3.zero;
        ContainedItem.transform.position = Slide.transform.position;
    }

}