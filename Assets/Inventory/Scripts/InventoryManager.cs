using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public Transform MainCharTransform;
    
    int selectedSlot = -1;
    int oldSelectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { ChangeSelectedSlot(0); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { ChangeSelectedSlot(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { ChangeSelectedSlot(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { ChangeSelectedSlot(3); }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { ChangeSelectedSlot(4); }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) { ChangeSelectedSlot(5); }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) { ChangeSelectedSlot(6); }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
            inventorySlots[selectedSlot].Deselect();

        inventorySlots[newValue].Select();
        oldSelectedSlot = selectedSlot;
        selectedSlot = newValue;
        ShowDescription();
        HideDescription();
    }
    void HideDescription()
    {
        if (oldSelectedSlot != -1)
        {
            InventoryItem itemInSlot = inventorySlots[oldSelectedSlot].GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
                itemInSlot.Hide();
        }
    }

    void ShowDescription()
    {
        InventoryItem itemInSlot = inventorySlots[selectedSlot].GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
            itemInSlot.Show();
    }
    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < 4 && item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnItem(item, slot);
                return true;
            }
        }
        return false;
    }
    public void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem invItem = newItemGO.GetComponent<InventoryItem>();
        invItem.InitializeItem(item);
    } 
    public void SpawnItem(GameObject itemPrefab) // Item drop kismi icin olusturuldu ama daha bitmedi
    {
        Vector3 spawnPosition = MainCharTransform.position + new Vector3(0f, 0f, 3f);
        GameObject newItemGO = Instantiate(itemPrefab , spawnPosition , Quaternion.identity);
    }
    
    public Item DeleteItem()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot != null)
        {
            Item item = itemInSlot.item;
            itemInSlot.count--;
            if(itemInSlot.count <= 0)
            {
                Destroy(itemInSlot.gameObject);
            }
            else
            {
                itemInSlot.RefreshCount();
            }
            return item;
        }
        return null;    
    } 
    public Item DropItem() // Envanterdeki itemleri disariya atmak icin olusturuldu.
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            itemInSlot.count--;
            SpawnItem(item.itemPrefab);
            if (itemInSlot.count <= 0)
            {
                Destroy(itemInSlot.gameObject);
            }
            else
            {
                itemInSlot.RefreshCount();
            }
            return item;
        }
        return null;
    }

   
}
