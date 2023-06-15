using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int id;
    Item item;
    DemoScript demoScript;
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    private void Start()
    {
        item = new Item();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        demoScript = GetComponent<DemoScript>();
        if (other.gameObject.CompareTag("Flashlight"))
        {
            id = 2;
            item.itemPrefab = other.gameObject;
            demoScript.PickupItem(id);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Food"))
        {
            id = 1;
            item.itemPrefab = other.gameObject;
            demoScript.PickupItem(id);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Medic"))
        {
            id = 0;
            item.itemPrefab = other.gameObject;
            demoScript.PickupItem(id);
            Destroy(other.gameObject);
        }
    }

    private void TryInteract()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactDistance, interactLayer);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Flashlight"))
            {
                PickUpItem(collider.gameObject, 2);
                return;
            }
            else if (collider.CompareTag("Food"))
            {
                PickUpItem(collider.gameObject, 1);
                return;
            }
            else if (collider.CompareTag("Medic"))
            {
                PickUpItem(collider.gameObject, 0);
                return;
            }
        }
    }

    private void PickUpItem(GameObject itemObject, int id)
    {
        DemoScript demoScript = GetComponent<DemoScript>();
        Item item = new Item();
        item.itemPrefab = itemObject;
        demoScript.PickupItem(id);
        Destroy(itemObject);
    }
}
