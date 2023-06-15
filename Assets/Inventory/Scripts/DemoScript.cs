using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    [SerializeField]
    private InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result)
        {
            Debug.Log("Item Added");
        }
        else
            Debug.Log("Item not Added");
    }
}
