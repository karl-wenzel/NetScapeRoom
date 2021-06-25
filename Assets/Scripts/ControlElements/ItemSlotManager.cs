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
    public Color ColorIsEmpty;
    public Color ColorIsFull;
    public Color ColorIsLocked;
    public Color ColorIsUnlocked;

    public Draggable ContainedItem;


    private bool IsEmpty = true;

    private SpriteRenderer spriteRenderer;
    private Color CurrentColor;



    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentColor = ColorIsEmpty;

        if (DefaultItem != null)
        {
            AddItem(DefaultItem);
            ContainedItem.SetPosition(transform.position);
        }
    }

    public void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, CurrentColor, Time.deltaTime * 10);
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

    public bool ContainsItem(GameObject Item)
    {
        foreach (Draggable Accept in Accepts)
        {
            if (ContainedItem == Item) return true;
        }

        return false;
    }


    public void AddItem(Draggable Item)
    {
        ContainedItem = Item;
        IsEmpty = false;

        if (IsLocked)
            LockItem();
        else
            UnlockItem();
            CurrentColor = ColorIsFull;
    }

    public void RemoveItem()
    {
        ContainedItem = null;
        IsEmpty = true;

        CurrentColor = ColorIsEmpty;
    }

    public void LockItem()
    {
        IsLocked = true;
        CurrentColor = ColorIsLocked;
        ContainedItem.GetComponent<Draggable>().SetEnableDrag(false);
    }

    public void UnlockItem()
    {
        IsLocked = false;

        if (IsEmpty) CurrentColor = ColorIsEmpty;
        else CurrentColor = ColorIsUnlocked;

        ContainedItem.GetComponent<Draggable>().SetEnableDrag(true);
    }
}
