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

    [Header("Item Inspector Prefab")]
    public GameObject inspector;


    private Vector3 StartMousePosition;
    private Vector3 StartWindowPosition;
    private Vector3 TargetPosition;
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
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * DragSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, CurrentScale, Time.deltaTime * ScaleSpeed);
    }

    public void Click()
    {
        Instantiate(inspector, new Vector3(0f, -3f, 0f), Quaternion.identity);
        Debug.Log("Instantiated item inspector " + inspector.name);
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

        if (IsSelectingItemSlot && SelectedItemSlot != null)
        {
            ItemSlotManager ItemSlot = SelectedItemSlot.GetComponent<ItemSlotManager>();
            if (ItemSlot.AcceptsNewItem(gameObject))
            {
                ItemSlot.AddItem(gameObject);
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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemSlot"))
        {
            IsSelectingItemSlot = true;
            SelectedItemSlot = collision;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsColliding = false;

        if (collision.CompareTag("ItemSlot"))
        {
            ItemSlotManager ItemSlot = SelectedItemSlot.GetComponent<ItemSlotManager>();

            if (ItemSlot.ContainsItem(gameObject))
            {
                ItemSlot.RemoveItem();
                IsSelectingItemSlot = false;
                SelectedItemSlot = null;
            }
        }
    }

}