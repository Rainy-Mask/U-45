using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CharacterMovement : MonoBehaviour
{
    // character movement
    private CharacterController characterController;
    [SerializeField] public float speed;

    [SerializeField] private CharacterEffects characterEffects;

    // character gravity
    private float gravity = -9.8f;
    private Vector3 velocity;

    [SerializeField] private Transform groundPos;
    public bool isGrounded;
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
    private GameObject panel;


    private void Start()
    {
        walkSpeed = speed;
        cam = Camera.main;  
        characterController = GetComponent<CharacterController>();
        characterEffects = GetComponent<CharacterEffects>();
        playerStats = GetComponent<PlayerStats>();
        panel = GameObject.Find("statusPanel");

        if (PlayerPrefs.HasKey("XPos")) //Oyun başladıktan sonra daha öncesinde kaydedilmiş mi onu kontrol ediyor .Kayededilmiş ise o değerleri yeni pozisyonumuz yapıyor
        {
            float XPos = PlayerPrefs.GetFloat("XPos");
            float YPos = PlayerPrefs.GetFloat("YPos");
            float ZPos = PlayerPrefs.GetFloat("ZPos");

            transform.position = new Vector3(XPos, YPos, ZPos);
        }
    }

    public void SavePos() //Karakterin pozisyonlarını kaydetmeye yarar
    {
        PlayerPrefs.SetFloat("XPos", transform.position.x);
        PlayerPrefs.SetFloat("YPos", transform.position.y);
        PlayerPrefs.SetFloat("ZPos", transform.position.z);

    }

    private void Update()
    {
        if (!mainInventory.activeSelf) // Sadece envanter kapalıyken karakterin hareketini kontrol et
        {
            DoMove();
            DoGravity();
            DoSprint();
        }
        playerStats.DecreaseSanity(0.5f * Time.deltaTime); // Katsayıyı ihtiyaçlarınıza göre ayarlayabilirsiniz
        ToggleInventory();
        UpdateStatusUI();
    }


    private void DoGravity()
    {
        isGrounded = Physics.CheckSphere(groundPos.position, groundDistance, groundMask); // Zeminde olup olmadığımızı anla
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
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 dir = transform.right * hor + transform.forward * ver;
        characterController.Move(dir * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            playerStats.DecreaseHunger(0.01f); // Yürüme ile açlık seviyesini azalt
            playerStats.DecreaseThirst(0.01f); // Yürüme ile susuzluk seviyesini azalt

            this.GetComponent<Animator>().SetBool("isWalking", true);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            playerStats.DecreaseHunger(0.005f); // Yürüme ile açlık seviyesini azalt
            playerStats.DecreaseThirst(0.005f); // Yürüme ile susuzluk seviyesini azalt

            this.GetComponent<Animator>().SetBool("isLeft", true);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            this.GetComponent<Animator>().SetBool("isLeft", false);
        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            playerStats.DecreaseHunger(0.005f); // Yürüme ile açlık seviyesini azalt
            playerStats.DecreaseThirst(0.005f); // Yürüme ile susuzluk seviyesini azalt

            this.GetComponent<Animator>().SetBool("isRight", true);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            this.GetComponent<Animator>().SetBool("isRight", false);
        }

        //back
        if (Input.GetKey(KeyCode.S))
        {
            playerStats.DecreaseHunger(0.005f); // Yürüme ile açlık seviyesini azalt
            playerStats.DecreaseThirst(0.005f); // Yürüme ile susuzluk seviyesini azalt

            this.GetComponent<Animator>().SetBool("isBack", true);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            this.GetComponent<Animator>().SetBool("isBack", false);
        }
    }

    private void DoSprint()
    {
        Jump();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //isRunning = true;
            this.GetComponent<Animator>().SetBool("isRunning", true);
            this.GetComponent<Animator>().SetBool("isGrounded", true);
            DOTween.To(() => speed, x => speed = x, runSpeed, 3); // speed degerimi 3 saniye icinde runspeed degerine esitle.
            cam.DOFieldOfView(90, 3);

            playerStats.DecreaseHunger(0.02f); // Yürüme ile açlık seviyesini azalt
            playerStats.DecreaseThirst(0.02f); // Yürüme ile susuzluk seviyesini azalt         

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
        if (panel != null)
        {
            Text hungerText = panel.transform.Find("HungerText").GetComponent<Text>();
            if (hungerText != null)
            {
                hungerText.text = "Hunger: " + playerStats.hunger.ToString("f0");
            }

            Text thirstText = panel.transform.Find("ThirstText").GetComponent<Text>();
            if (thirstText != null)
            {
                thirstText.text = "Thirst: " + playerStats.thirst.ToString("f0");
            }

            Text sanityText = panel.transform.Find("SanityText").GetComponent<Text>();
            if (sanityText != null)
            {
                sanityText.text = "Sanity: " + playerStats.sanity.ToString("f0");
                //Debug.Log("Sanity: " + playerStats.sanity.ToString()); // Akıl sağlığı değerini konsola yazdır
            }
        }
    }
}




