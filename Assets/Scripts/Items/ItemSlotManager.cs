using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotManager : MonoBehaviour
{
    public bool LockItem = true;
    public GameObject[] Accepts;

    [Header("Coloring")]
    public Color ColorIsEmpty;
    public Color ColorIsFull;

    private GameObject ContainedItem;
    private bool IsEmpty = true;

    private SpriteRenderer spriteRenderer;
    private Color CurrentColor;



    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentColor = ColorIsEmpty;
    }

    public void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, CurrentColor, Time.deltaTime * 10);
    }


    public bool AcceptsNewItem(GameObject NewObject)
    {
        if (ContainedItem != null) return false;
        if (!AcceptsItemType(NewObject)) return false;

        return true;
    }

    private bool AcceptsItemType(GameObject Item)
    {
        foreach (GameObject Accept in Accepts)
        {
            if (Accept.GetType() == Item.GetType()) return true;
        }

        return false;
    }

    public bool ContainsItem(GameObject Item)
    {
        foreach (GameObject Accept in Accepts)
        {
            if (ContainedItem == Item) return true;
        }

        return false;
    }


    public void AddItem(GameObject Item)
    {
        ContainedItem = Item;
        IsEmpty = false;

        if (LockItem) Item.GetComponent<Draggable>().SetEnableDrag(false);

        CurrentColor = ColorIsFull;
    }

    public void RemoveItem()
    {
        ContainedItem = null;
        IsEmpty = true;

        CurrentColor = ColorIsEmpty;
    }
}
