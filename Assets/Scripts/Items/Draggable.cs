using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    public bool EnableDrag = true;

    [Header("Visuals")]
    public float DragSpeed = 10;
    public float ScaleSpeed = 0.01f;

    public float DragScaleMultiplier;

    [Header("Item Inspector")]
    public ClickableObject Clickable;
    public GameEventStartMinigame inspector;
    [TextArea]
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
    private Vector3 TargetScale;

    private ItemAudio m_audio;

    public GameObject DestroyOnClick;
    public GameObject EnableOnClick;
    public GameObject DestroyOnDrag;
    public bool IsTutorialStick;

    public void Start()
    {
        TargetPosition = transform.position;

        OriginalScale = transform.localScale;
        CurrentScale = transform.localScale;
        TargetScale = OriginalScale * DragScaleMultiplier;

        m_audio = GetComponent<ItemAudio>();
    }

    public void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition, Time.deltaTime * DragSpeed);
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        TargetPosition = pos;
    }



    public void Click()
    {
        if (DestroyOnClick != null) Destroy(DestroyOnClick);

        OpenInspector();

        if (IsTutorialStick)
        {
            if (EnableOnClick != null) EnableOnClick.SetActive(true);
            EnableDrag = true;
        }

    }

    public void BeginDrag()
    {
        StartMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartWindowPosition = transform.position;
        LastPosition = transform.position;

        CurrentScale = OriginalScale;
        TargetScale = OriginalScale * DragScaleMultiplier;
        StartCoroutine("LerpScale");

        m_audio.PlayPickUp();
    }

    public void Drag()
    {
        if (!EnableDrag) return;
        if (DestroyOnDrag != null) Destroy(DestroyOnDrag);

        Vector3 MouseOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - StartMousePosition;
        MouseOffset.z = 0f;
        TargetPosition = StartWindowPosition + MouseOffset;

        IsDragging = true;
    }

    public void EndDrag()
    {
        CurrentScale = OriginalScale * DragScaleMultiplier;
        TargetScale = OriginalScale;
        StartCoroutine("LerpScale");


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
                    TargetScale = SelectedItemSlot.GetItemScale();
                    StartCoroutine("LerpScale");

                }
                else if (SelectedItemSlot.ContainsItem(this))
                {
                    Debug.Log("Item remains in the same Itemslot");
                    TargetPosition = SelectedItemSlot.GetItemPosition();
                    TargetScale = SelectedItemSlot.GetItemScale();
                    StartCoroutine("LerpScale");
                }
                else if(LastItemSlot != null && LastItemSlot.AcceptsNewItem(this))
                {
                    Debug.Log("Item send back to previous Itemslot");
                    if(LastItemSlot != null) SelectedItemSlot = LastItemSlot;
                    TargetPosition = SelectedItemSlot.GetItemPosition();
                    TargetScale = SelectedItemSlot.GetItemScale();
                    StartCoroutine("LerpScale");

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


        if (SelectedItemSlot == null) m_audio.PlayDrop();
        else m_audio.PlayInsert();
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

    public void OpenInspector()
    {
        inspector.MinigamePrefab.GetComponent<HoldsText>().SetDescription(Description);
        Clickable.AddMinigame(inspector);
        Clickable.Clicked();
    }

    IEnumerator LerpScale()
    {
        float progress = 0;

        while (progress <= 1)
        {
            transform.localScale = Vector3.Lerp(CurrentScale, TargetScale, progress);
            progress += Time.deltaTime * ScaleSpeed;
            yield return null;
        }
        transform.localScale = TargetScale;

    }




}
