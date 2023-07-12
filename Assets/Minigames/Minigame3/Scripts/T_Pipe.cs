using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class T_Pipe : MonoBehaviour
{
    Rigidbody rb;
    public bool taken = false;
    [HideInInspector]
    public bool hasReseted = false;
    public bool hasDestroyed = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if (taken) 
        {
            GameObject obj = GameObject.FindGameObjectWithTag("pivot");
            rb.MovePosition(obj.transform.position);
            rb.MoveRotation(Quaternion.LookRotation(Camera.main.transform.forward));
            rb.useGravity = false;
            if (hasDestroyed)
            {
                taken = false;
            }
        }
        else
        {
            rb.useGravity = true;
        }
        if (!hasReseted) 
        {
            ResetForce();
            hasReseted = true;
        }

    }

    public void ResetForce()
    {
        rb.isKinematic = true;
        rb.isKinematic = false;
    }

    public void Force()
    {
        rb.AddForce(Camera.main.transform.forward * 30, ForceMode.Impulse);
    }
    private void OnDestroy()
    {
        taken = false;
    }
}
