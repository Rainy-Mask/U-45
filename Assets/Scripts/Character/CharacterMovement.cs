using UnityEngine;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed;
    private float gravity = -9.8f;
    private Vector3 velocity;

    [SerializeField] private Transform groundPos;
    [SerializeField] private bool isGrounded;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private float walkSpeed;
    private float runSpeed = 5f;
    private bool isRunning;

    private Camera cam;

    [SerializeField] private float jumpHeight = 3f;
    private bool canJump;

    private void Start()
    {
        walkSpeed = speed;
        cam = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        DoMove();
        DoGravity();
        DoJump();
        DoSprint();
    }

    private void DoGravity()
    {
        isGrounded = Physics.CheckSphere(groundPos.position, groundDistance, groundMask);
        velocity.y += gravity * Time.deltaTime;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            canJump = true; // Zemindeyken zıplamayı sağlar
        }

        characterController.Move(velocity * Time.deltaTime);
    }

    private void DoMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * hor + transform.forward * ver;
        characterController.Move(dir * speed * Time.deltaTime);
    }

    private void DoJump()
    {
        if (canJump && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = false; // Tekrar yere değene kadar zıplamayı etkisiz hale getirir
        }
    }

    private void DoSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded) // Sprint yapmadan önce zeminde olup olmadığını kontrol et
        {
        isRunning = true;

        DOTween.To(() => speed, x => speed = x, runSpeed, 3);
        cam.DOFieldOfView(90, 3);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || !isGrounded) // Eğer shift bırakılırsa ya da karakter zeminde değilse sprinti kes
        {
        isRunning = false;

        DOTween.To(() => speed, x => speed = x, walkSpeed, 3);
        cam.DOFieldOfView(60, 3);
        }
    }

}
