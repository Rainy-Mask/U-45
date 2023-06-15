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
    //private bool isRunning;

    // inventory scene
    public GameObject mainInventory;

    [SerializeField] private float jumpHeight = 5f;

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
        DoSprint();
        CheckInventory();
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
        Jump();
        if (Input.GetKeyDown(KeyCode.W))
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            Vector3 dir = transform.right * hor + transform.forward * ver;
            characterController.Move(dir * speed * Time.deltaTime);
            this.GetComponent<Animator>().SetBool("isWalking", true);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
            //Jump();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }


    }

    private void DoSprint()
    {
        Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            //isRunning = true;
            this.GetComponent<Animator>().SetBool("isRunning", true);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
            DOTween.To(() => speed, x => speed = x, runSpeed, 3); // speed degerimi 3 saniye icinde runspeed degerine esitle.
            cam.DOFieldOfView(90, 3);

            //Jump();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //isRunning = false;
            this.GetComponent<Animator>().SetBool("isRunning", false);
            DOTween.To(() => speed, x => speed = x, walkSpeed, 3);
            cam.DOFieldOfView(60, 3);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            isGrounded = false;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            this.GetComponent<Animator>().SetBool("isJumping", true);
            this.GetComponent<Animator>().SetBool("isGrounded", false);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //this.GetComponent<Animator>().applyRootMotion = false;
            this.GetComponent<Animator>().SetBool("isJumping", false);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
        }
    }

    void CheckInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mainInventory.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainInventory.SetActive(false);
        }
    }

}
