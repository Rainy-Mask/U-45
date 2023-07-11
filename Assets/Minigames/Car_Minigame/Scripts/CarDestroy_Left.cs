using UnityEngine;

public class CarDestroy_Left : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("npc_2"))
        {
            Destroy(gameObject);  
        }
    }
}
