using UnityEngine;
using DG.Tweening;
public class CharacterMovement : MonoBehaviour
{

    // character movement
    private CharacterController characterController;
    [SerializeField] private float speed;

    // character gravity
    private float gravity = -9.8f;
    private Vector3 velocity;

    [SerializeField] private Transform groundPos;
    [SerializeField] private bool isGrounded;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    // character run
    private float walkSpeed;
    private float runSpeed = 5f;
    private Camera cam;
    private bool isRunning;



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
    }

    private void DoGravity()
    {
        isGrounded = Physics.CheckSphere(groundPos.position, groundDistance, groundMask); // Zeminde olup olmadýðýmýzý anla
        velocity.y += gravity * Time.deltaTime;

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
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

    private void DoSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            isRunning = true;

            DOTween.To(() => speed, x => speed = x, walkSpeed, 3); // speed deðerimi 3 saniye içinde runspeed deðerine eþitle.
            cam.DOFieldOfView(90, 3);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;

            DOTween.To(() => speed, x => speed = x, walkSpeed, 3);
            cam.DOFieldOfView(60, 3);
        }
    }
}
