using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroy_Right : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("npc_1"))
        {
            Destroy(gameObject);
        }
    }
}
