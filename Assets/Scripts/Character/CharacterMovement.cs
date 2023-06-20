using UnityEngine;
using UnityEngine.UI;
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

    PlayerStats playerStats;
    private GameObject statusPanel;


    private void Start()
    {
        walkSpeed = speed;
        cam = Camera.main;  
        characterController = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        statusPanel = GameObject.Find("StatusPanel");
        

    }

        private void Update()
    {
        if (!mainInventory.activeSelf) // Sadece envanter kapalıyken karakterin hareketini kontrol et
        {
            DoMove();
            DoGravity();
            DoSprint();
        }

        ToggleInventory();
        UpdateStatusUI();
    }


    private void DoGravity()
    {
        isGrounded = Physics.CheckSphere(groundPos.position, groundDistance, groundMask); // Zeminde olup olmad���m�z� anla
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

        /* playerStats.DecreaseHunger(0.1f); // Yürüme ile açlık seviyesini azalt
        playerStats.DecreaseThirst(0.1f); // Yürüme ile susuzluk seviyesini azalt !!!!!!!!!!!!!!!!! Açlık SUSUZLUK*/

        this.GetComponent<Animator>().SetBool("isWalking", true);
        this.GetComponent<Animator>().SetBool("isGrounded", true);
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

/*         playerStats.DecreaseHunger(0.2f); // Sprint ile açlık seviyesini daha hızlı azalt
        playerStats.DecreaseThirst(0.2f); // Sprint ile susuzluk seviyesini daha hızlı azalt    !!!!!!!!!!!!!!!!!!!!! Açlık Susuzluk*/         

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

    /* void CheckInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mainInventory.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainInventory.SetActive(false);
        }
    } */

    public void ToggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool isInventoryActive = !mainInventory.activeSelf; // Envanter durumunu kontrol et
            mainInventory.SetActive(isInventoryActive); // Envanteri aç veya kapat

            if (isInventoryActive)
            {
                characterController.enabled = false; // Karakter kontrolünü devre dışı bırak
                Cursor.lockState = CursorLockMode.None;
                this.GetComponent<Animator>().SetBool("isWalking", false); // Yürüme animasyonunu durdur
                this.GetComponent<Animator>().SetBool("isRunning", false); // Sprint animasyonunu durdur
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                characterController.enabled = true; // Karakter kontrolünü etkinleştir
            }
        }
    }

    private void UpdateStatusUI()
    {
    if (statusPanel != null)
    {
        Text hungerText = statusPanel.transform.Find("HungerText").GetComponent<Text>();
        if (hungerText != null)
        {
            hungerText.text = "Hunger: " + playerStats.hunger.ToString();
        }

        Text thirstText = statusPanel.transform.Find("ThirstText").GetComponent<Text>();
        if (thirstText != null)
        {
            thirstText.text = "Thirst: " + playerStats.thirst.ToString();
        }
    }
    }




}




