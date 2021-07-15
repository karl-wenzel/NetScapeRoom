using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotManager : MonoBehaviour
{
    [Header("Item Management")]
    public bool IsLocked = true;
    public Draggable[] Accepts;
    public Draggable DefaultItem;

    [Header("Coloring")]
    public bool CanChangeColor = true;
    public Color ColorIsEmpty;
    public Color ColorIsFull;
    public Color ColorIsLocked;
    public Color ColorIsUnlocked;

    public Draggable ContainedItem;

    public Transform ItemPosition;


    private bool IsEmpty = true;

    private SpriteRenderer spriteRenderer;
    private Color CurrentColor;

    public ClickableObject[] EnableClickable;



    public void Start()
    {
        if (ItemPosition == null) {
            ItemPosition = transform;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (CanChangeColor) CurrentColor = ColorIsEmpty;

        if (DefaultItem != null)
        {
            AddItem(DefaultItem);
            ContainedItem.SetPosition(transform.position);
        }
    }

    public void Update()
    {
        if (CanChangeColor) spriteRenderer.color = Color.Lerp(spriteRenderer.color, CurrentColor, Time.deltaTime * 10);

        if (ContainedItem != null) IsEmpty = false;
    }


    public bool AcceptsNewItem(Draggable NewObject)
    {
        if (!IsEmpty) return false;
        if (!AcceptsItemType(NewObject)) return false;

        return true;
    }

    private bool AcceptsItemType(Draggable Item)
    {
        foreach (Draggable Accept in Accepts)
        {
            if (Accept == Item) return true;
        }

        return false;
    }

    public bool ContainsItem(Draggable Item)
    {
        foreach (Draggable Accept in Accepts)
        {
            if (ContainedItem == Item) return true;
        }

        return false;
    }

    public bool CompareItem(Draggable item)
    {
        return item == ContainedItem;
    }


    public void AddItem(Draggable Item)
    {

        ContainedItem = Item;
        ContainedItem.SetItemSlot(this);
        ContainedItem.SetLayer("ControlElements", 1);
        ContainedItem.SetPosition(ItemPosition.position);
        ContainedItem.SetCurrentScale(ItemPosition.localScale);
        IsEmpty = false;

        foreach (ClickableObject item in EnableClickable)
        {
            item.Activate();
        }

        if (IsLocked)
            LockItem();
        else
            UnlockItem();
            if (CanChangeColor) CurrentColor = ColorIsFull;
    }

    public void RemoveItem()
    {
        //ContainedItem.SetLayer("Items", 0);
        ContainedItem = null;
        IsEmpty = true;

        if (CanChangeColor) CurrentColor = ColorIsEmpty;
    }

    public void LockItem()
    {
        IsLocked = true;
        ContainedItem.GetComponent<Draggable>().SetEnableDrag(false);

        if(CanChangeColor) CurrentColor = ColorIsLocked;
    }

    public void UnlockItem()
    {
        IsLocked = false;

        if (CanChangeColor)
        {
            if (IsEmpty) CurrentColor = ColorIsEmpty;
            else CurrentColor = ColorIsUnlocked;
        }

        ContainedItem.SetLayer("Items", 1);
        ContainedItem.GetComponent<Draggable>().SetEnableDrag(true);
    }

    public bool CheckIfEmpty()
    {
        return IsEmpty;
    }

    public Vector3 GetItemPosition()
    {
        return ItemPosition.position;
    }

    public Vector3 GetItemScale()
    {
        return ItemPosition.localScale;
    }
}
