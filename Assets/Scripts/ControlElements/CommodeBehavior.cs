using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommodeBehavior : MonoBehaviour
{

    public Transform ItemPositionOpen;
    public Transform ItemPositionClosed;

    public GameObject ContainedItem;

    public LeverAudio audio;


    private Vector3 TargetPosition;
    private bool IsOpen = false;

    private ToogleSprites sprite;


    public void Start()
    {

        ContainedItem.GetComponent<Draggable>().enabled = false;
        ContainedItem.GetComponent<BoxCollider2D>().enabled = false;
        ContainedItem.GetComponent<SpriteRenderer>().sortingLayerName = "ControlElements";
        ContainedItem.GetComponent<SpriteRenderer>().sortingOrder = 1;

        sprite = GetComponent<ToogleSprites>();
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
        if (ContainedItem != null)
        {
            Draggable draggable = ContainedItem.GetComponent<Draggable>();
            draggable.enabled = true;
            draggable.SetPosition(ItemPositionOpen.position);

            ContainedItem.GetComponent<BoxCollider2D>().enabled = true;
            ContainedItem.GetComponent<SpriteRenderer>().sortingLayerName = "Items";
        }

        sprite.SetOn();

        audio.PlayClickOn();
    }

    public void Close()
    {
        if (ContainedItem != null)
        {
            if (ContainedItem.transform.position != ItemPositionOpen.position)
            {
                ContainedItem = null;
            }
            else
            {
                ContainedItem.GetComponent<BoxCollider2D>().enabled = false;
                ContainedItem.GetComponent<SpriteRenderer>().sortingLayerName = "ControlElements";
                ContainedItem.GetComponent<Draggable>().SetPosition(ItemPositionClosed.position);
            }
        }

        sprite.SetOff();

        audio.PlayClickOff();
    }

}