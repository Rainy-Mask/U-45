using UnityEngine;
using UnityEngine.TextCore.Text;

public class MouseLook : MonoBehaviour
{
    public float sensivity = 100f;
    public Transform body;
    private float xRot = 0;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float hor = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float ver = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRot -= ver;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        body.Rotate(Vector3.up * hor);
    }
}

