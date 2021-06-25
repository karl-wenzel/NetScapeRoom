using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool EnableDrag = true;

    [Header("Visuals")]
    public float DragSpeed = 10;
    public float ScaleSpeed = 20;

    public float DragScaleMultiplier;

    [Header("Item Inspector")]
    public GameObject inspector;
    public string Description;


    private Vector3 StartMousePosition;
    private Vector3 StartWindowPosition;
    public Vector3 TargetPosition;
    private Vector3 LastPosition;

    private bool IsDragging = false;
    private bool IsColliding = false;
    private bool IsSelectingItemSlot;

    private Collider2D SelectedItemSlot;

    private Vector3 OriginalScale;
    private Vector3 CurrentScale;


    public void Start()
    {
        TargetPosition = transform.position;

        OriginalScale = transform.localScale;
        CurrentScale = OriginalScale;
    }

    public void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition, Time.deltaTime * DragSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, CurrentScale, Time.deltaTime * ScaleSpeed);
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        TargetPosition = pos;
    }

    public void Click()
    {

            GameObject newInspector = Instantiate(inspector, new Vector3(0, 0, 0), Quaternion.identity);
            newInspector.GetComponent<HoldsText>().SetDescription(Description);
            newInspector.transform.SetParent(GameObject.Find("Canvas").transform, false);

    }

    public void BeginDrag()
    {
        StartMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartWindowPosition = transform.position;
        LastPosition = transform.position;

        CurrentScale = OriginalScale * DragScaleMultiplier;
    }

    public void Drag()
    {
        if (!EnableDrag) return;

        Vector3 MouseOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - StartMousePosition;
        MouseOffset.z = 0f;
        TargetPosition = StartWindowPosition + MouseOffset;

        IsDragging = true;
    }

    public void EndDrag()
    {
        CurrentScale = OriginalScale;

        if (!IsDragging) Click();

        IsDragging = false;

        if (IsSelectingItemSlot)
        {
            ItemSlotManager ItemSlot = SelectedItemSlot.GetComponent<ItemSlotManager>();
            if (ItemSlot.AcceptsNewItem(this))
            {
                ItemSlot.AddItem(this);
                TargetPosition = SelectedItemSlot.transform.position;
                IsColliding = false;
            }
            else
            {
                IsColliding = true;
            }
        }

        if (IsColliding) TargetPosition = LastPosition;
        LastPosition = transform.position;
    }


    public void SetEnableDrag(bool drag)
    {
        EnableDrag = drag;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsColliding = true;

        if (collision.CompareTag("ItemSlot"))
        {
            IsSelectingItemSlot = true;
            SelectedItemSlot = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsColliding = false;

        if (collision.CompareTag("ItemSlot"))
        {
            ItemSlotManager ItemSlot = SelectedItemSlot.GetComponent<ItemSlotManager>();
            ItemSlot.RemoveItem();
            IsSelectingItemSlot = false;
            SelectedItemSlot = null;
        }
    }

}