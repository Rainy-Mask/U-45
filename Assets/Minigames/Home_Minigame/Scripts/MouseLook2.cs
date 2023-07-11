using UnityEngine;

public class MouseLook2 : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform body;
    public float jumpCameraOffset = 1.9f; // Zıplama animasyonunda kamera yukarı kaydırma miktarı
    public float cameraResetSpeed = 2.0f; // Kamera resetleme hızı

    private float xRot = 0;
    private float yRot = 0;
    private float originalCameraHeight;
    private bool isJumping = false;
    private CharacterMovement_Home characterMovement;
    //private CharacterEffects characterEffects;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalCameraHeight = transform.localPosition.y; // Kameranın orijinal yüksekliği
        characterMovement = body.GetComponent<CharacterMovement_Home>();
        //characterEffects = body.GetComponent<CharacterEffects>();

        /*if (characterMovement == null)
        {
            Debug.LogError("CharacterMovement component not found on the body!");
        }

        if (characterEffects == null)
        {
            Debug.LogError("CharacterEffects component not found on the body!");
        }*/
    }

    private void Update()
    {
        float hor = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float ver = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRot -= ver;
        yRot += hor;

        xRot = Mathf.Clamp(xRot, -90f, 90f);
        body.Rotate(Vector3.up * hor);
        // Baş dönmesi aktifken y ekseni dönüşünü de uygula
        /*if (characterEffects.IsDizzy)
        {
            body.rotation = Quaternion.Euler(0, yRot, 0);
        }
        else
        {
            
        }*/

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        if (Input.GetButtonDown("Jump") && characterMovement.isGrounded)
        {
            isJumping = true;
        }
    }

    private void LateUpdate()
    {
        if (isJumping)
        {
            Vector3 jumpCameraPosition = transform.localPosition; // Kameranın pozisyonu alınır
            jumpCameraPosition.y = originalCameraHeight + jumpCameraOffset; // Kameranın yüksekliği artırılır
            transform.localPosition = jumpCameraPosition; // Kameranın pozisyonu güncellenir

            isJumping = false;
        }
        else
        {
            Vector3 resetCameraPosition = transform.localPosition; // Kameranın pozisyonu alınır
            resetCameraPosition.y = originalCameraHeight; // Kameranın yüksekliği sıfırlanır
            transform.localPosition = Vector3.Lerp(transform.localPosition, resetCameraPosition, cameraResetSpeed * Time.deltaTime); // Kameranın pozisyonu eski haline doğru yumuşak bir geçiş yapar
        }
    }
}
