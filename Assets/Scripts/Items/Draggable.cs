using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
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
    private bool HasItemSlot;

    private ItemSlotManager SelectedItemSlot;

    private Vector3 OriginalScale;
    private Vector3 CurrentScale;

    private ItemAudio audio;


    public void Start()
    {
        TargetPosition = transform.position;

        OriginalScale = transform.localScale;
        CurrentScale = OriginalScale;

        audio = GetComponent<ItemAudio>();
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
        if (inspector != null)
        {
            GameObject newInspector = Instantiate(inspector, new Vector3(0, 0, 0), Quaternion.identity);
            newInspector.GetComponent<HoldsText>().SetDescription(Description);
            newInspector.transform.SetParent(SpawnPositionController.spawnPositionControllerInstance.GetCanvas().transform, false);
        }
    }

    public void BeginDrag()
    {
        StartMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartWindowPosition = transform.position;
        LastPosition = transform.position;

        CurrentScale = OriginalScale * DragScaleMultiplier;

        audio.PlayPickUp();
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

        

        this.GetComponent<BoxCollider2D>().enabled = false;

        int layerMask = LayerMask.GetMask("ControllElement");

        RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, Vector3.forward, layerMask);

        this.GetComponent<BoxCollider2D>().enabled = true;

        if (hit.collider != null)
        {

            if (hit.collider.CompareTag("ItemSlot"))
            {
                ItemSlotManager LastItemSlot = SelectedItemSlot;

                Debug.Log("Found Itemslot");

                SelectedItemSlot = hit.collider.GetComponent<ItemSlotManager>();

                if (SelectedItemSlot.AcceptsNewItem(this))
                {
                    Debug.Log("Itemslot accepts item");
                    SelectedItemSlot.AddItem(this);

                }
                else if (SelectedItemSlot.ContainsItem(this))
                {
                    Debug.Log("Item remains in the same Itemslot");
                    TargetPosition = SelectedItemSlot.GetItemPosition();
                    CurrentScale = SelectedItemSlot.GetItemScale();
                }
                else if(LastItemSlot != null && LastItemSlot.AcceptsNewItem(this))
                {
                    Debug.Log("Item send back to previous Itemslot");
                    if(LastItemSlot != null) SelectedItemSlot = LastItemSlot;
                    TargetPosition = SelectedItemSlot.GetItemPosition();
                    CurrentScale = SelectedItemSlot.GetItemScale();

                }
                else
                {
                    Debug.Log("Item send back to Last Position");
                    TargetPosition = LastPosition;
                }
            }
        }
        else if(SelectedItemSlot != null) 
        { 
            SelectedItemSlot.RemoveItem();
            SelectedItemSlot = null;
        }




        if (!IsDragging) Click();

        IsDragging = false;


        if (IsColliding) TargetPosition = LastPosition;
        LastPosition = transform.position;


        if (SelectedItemSlot == null) audio.PlayDrop();
        else audio.PlayInsert();
    }

    public void SetItemSlot(ItemSlotManager Slot)
    {
        SelectedItemSlot = Slot;
    }

    public void SetLayer(String layer, int order)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = layer;
        spriteRenderer.sortingOrder = order;
    }


    public void SetEnableDrag(bool drag)
    {
        EnableDrag = drag;
    }

    public void SetCurrentScale(Vector3 scale)
    {
        CurrentScale = scale;
    }



}
