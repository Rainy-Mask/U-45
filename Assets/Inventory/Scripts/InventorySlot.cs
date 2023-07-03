using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, deselectedColor;
    InventoryItem inventoryItem;

    private void Awake()
    {
        Deselect();
        inventoryItem = GetComponent<InventoryItem>();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = deselectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            InventoryItem invItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            invItem.parentAfterDrag = transform;
        }
    }
}
