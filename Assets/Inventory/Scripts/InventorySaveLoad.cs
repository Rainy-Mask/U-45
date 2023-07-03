using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using static UnityEditor.Progress;

[System.Serializable]
public class InventoryItemData
{
    public string itemName;
    public int itemCount;
}

public class InventorySaveLoad : MonoBehaviour
{
    public Item[] itemsToPickup;
    public List<InventoryItemData> itemDataList = new List<InventoryItemData>();
    public InventoryManager inventoryManager;
    private string inventoryDataPath = "inventory.json";

    public void SaveInventory()
    {
        // Dosya yolu kontrolü
        if (string.IsNullOrEmpty(inventoryDataPath))
        {
            Debug.LogError("Inventory data path is not set!");
            return;
        }

        Debug.LogFormat("Saving inventory to: {0}", inventoryDataPath);

        itemDataList.Clear();

        foreach (InventorySlot slot in inventoryManager.inventorySlots)
        {
            InventoryItem item = slot.GetComponentInChildren<InventoryItem>();
            if (item != null)
            {
                InventoryItemData itemData = new InventoryItemData
                {
                    itemName = item.item.name,
                    itemCount = item.count
                };

                itemDataList.Add(itemData);
            }
        }

        string jsonData = JsonConvert.SerializeObject(itemDataList, Formatting.Indented);
        File.WriteAllText(inventoryDataPath, jsonData);
    }

    private void Start()
    {
        inventoryDataPath = Path.Combine(Application.persistentDataPath, "inventory.json");
        LoadInventory(); // LoadInventory fonksiyonunu çaðýr
    }

    public void LoadInventory()
    {
        // itemDataList'i dosyadan yükleme iþlemleri yapýlýr
        if (File.Exists(inventoryDataPath))
        {
            string jsonData = File.ReadAllText(inventoryDataPath);
            itemDataList = JsonConvert.DeserializeObject<List<InventoryItemData>>(jsonData);
            Debug.Log("Ýf içi");

            foreach (InventoryItemData itemData in itemDataList)
            {
                for (int i = 0; i < itemData.itemCount; i++)
                {
                    if (itemData.itemName == "Arveles")
                    {
                        inventoryManager.AddItem(itemsToPickup[1]);
                    }
                    if (itemData.itemName == "Apple")
                    {
                        inventoryManager.AddItem(itemsToPickup[0]);
                    }
                }
            }
        }
    }
}

