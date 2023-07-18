using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    private void Start()
    {
        
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

    public void DeleteItem()
    {
        Item recievedItem = inventoryManager.DeleteItem();
        if (recievedItem != null)
        {
            Debug.Log("Recieved item : " + recievedItem);
        }
        else
        {
            Debug.Log("Not recieved");
        }
    }
    public void DropItem() 
    {
        Item recievedItem = inventoryManager.DropItem();
        
        if (recievedItem != null)
        {
            Debug.Log("Droped item : " + recievedItem);
        }
        else
        {
            Debug.Log("Not recieved");
        }
    }

    public void UseItem()
    {
        Item recievedItem = inventoryManager.UseItem();
        if (recievedItem != null)
        {
            Debug.Log("Used item : " + recievedItem + " " + recievedItem.description);
        }
        else
        {
            Debug.Log("Not recieved");
        }
    }
}
