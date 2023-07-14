using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TriggerItem : MonoBehaviour
{
    private bool isEnd = false;
    private float interactItemCount = 8;
    [SerializeField] private Animator exitDoorAnim;
    [SerializeField] private Light exitDoorLight;
    [SerializeField] private TextMeshProUGUI interactItemCount_Text;
    private bool triggerClock = false;
    private bool triggerTV = false;
    private bool commode = false;
    private bool frame_1 = false;
    private bool frame_2 = false;
    private bool frame_3 = false;
    private bool frame_4 = false;
    private bool frame_5 = false;
    private bool commode_1 = false;
    private bool toy = false;

    [Header("Obje etkilesimi sonrasi text")]
    [SerializeField] private TextMeshProUGUI itemText;

    [Header("Televizyon etkilesimi")]
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject videoGameobject;
    [SerializeField] private AudioSource tvOnAudio;

    [Header("Komidin Animasyon")]
    [SerializeField] private Animator commodeAnim;
    [SerializeField] private AudioSource shelfOpenAudio;
    [SerializeField] private GameObject uiKeyGameobject;
    [SerializeField] private AudioSource keySound;

    [Header("Door")]
    private bool hasKey = false;
    private bool door = false;
    [SerializeField] private Animator doorAnim;
    [SerializeField] private AudioSource doorAudio;

    [Header("Txt anim")]
    public float delay = 0.1f;
    string text;


    [Header("Commode 1 anim")]
    [SerializeField] private Animator commode_1_anim;
    private void Start()
    {
        itemText.enabled = false;
        exitDoorLight.enabled = false;
        itemText.text = "";
        video.enabled = false;
        videoGameobject.SetActive(false);
    }
    void Update()
    {
        ItemIntreacts();
        interactItemCount_Text.text = interactItemCount.ToString();
    }

    void ItemIntreacts()
    {
        if (triggerClock && Input.GetKeyDown(KeyCode.E))
        {
            GameObject clockGameObject = GameObject.FindGameObjectWithTag("clock");
            BoxCollider[] clockBoxColliders = clockGameObject.GetComponents<BoxCollider>();
            Destroy(clockBoxColliders[1]);
            itemText.enabled = true;
            StartCoroutine(ClockTexts());
            StartCoroutine(EnabledText());
            triggerClock = false;
            interactItemCount--;
        }
        if (triggerTV && Input.GetKeyDown(KeyCode.E))
        {
            GameObject tvGameObject = GameObject.FindGameObjectWithTag("television");
            BoxCollider[] tvBoxColliders = tvGameObject.GetComponents<BoxCollider>();
            Destroy(tvBoxColliders[1]);
            tvOnAudio.Play();
            videoGameobject.SetActive(true);
            video.enabled = true;
            video.Play();
            StartCoroutine(TVTexts());
            StartCoroutine(EnabledText());
            triggerTV = false;
            interactItemCount--;
        }
        if (commode && Input.GetKeyDown(KeyCode.E))
        {
            GameObject commodeGameObject = GameObject.FindGameObjectWithTag("commode");
            BoxCollider[] commodeBoxColliders = commodeGameObject.GetComponents<BoxCollider>();
            Destroy(commodeBoxColliders[1]);
            StartCoroutine(CommodeAudio());
            commodeAnim.SetBool("open", true);
            StartCoroutine(Commode());
            StartCoroutine(EnabledText());
            commode = false;
            interactItemCount--;
        }
        if (commode_1 && Input.GetKeyDown(KeyCode.E))
        {
            GameObject commode1GameObject = GameObject.FindGameObjectWithTag("commode_1");
            BoxCollider[] commode1BoxColliders = commode1GameObject.GetComponents<BoxCollider>();
            Destroy(commode1BoxColliders[1]);
            StartCoroutine(CommodeAudio());
            commode_1_anim.SetBool("open", true);
            StartCoroutine(Commode1());
            StartCoroutine(EnabledText());
            commode_1 = false;
        }
        if (frame_1 && Input.GetKeyDown(KeyCode.E))
        {
            GameObject frame_1GameObject = GameObject.FindGameObjectWithTag("frame_1");
            BoxCollider[] frame_1BoxColliders = frame_1GameObject.GetComponents<BoxCollider>();
            Destroy(frame_1BoxColliders[1]);
            itemText.enabled = true;
            StartCoroutine(Frame_1());
            StartCoroutine(EnabledText());
            frame_1 = false;
            interactItemCount--;
        }
        if (frame_2 && Input.GetKeyDown(KeyCode.E))
        {
            GameObject frame_2GameObject = GameObject.FindGameObjectWithTag("frame_2");
            BoxCollider[] frame_2BoxColliders = frame_2GameObject.GetComponents<BoxCollider>();
            Destroy(frame_2BoxColliders[1]);
            itemText.enabled = true;
            StartCoroutine(Frame_2());
            StartCoroutine(EnabledText());
            frame_2 = false;
            interactItemCount--;
        }
        if (frame_3 && Input.GetKeyDown(KeyCode.E))
        {
            GameObject frame_3GameObject = GameObject.FindGameObjectWithTag("frame_3");
            BoxCollider[] frame_3BoxColliders = frame_3GameObject.GetComponents<BoxCollider>();
            Destroy(frame_3BoxColliders[1]);
            itemText.enabled = true;
            StartCoroutine(Frame_3());
            StartCoroutine(EnabledText());
            frame_3 = false;
            interactItemCount--;
        }
        if (frame_4 && Input.GetKeyDown(KeyCode.E))
        {
            GameObject frame_4GameObject = GameObject.FindGameObjectWithTag("frame_4");
            BoxCollider[] frame_4BoxColliders = frame_4GameObject.GetComponents<BoxCollider>();
            Destroy(frame_4BoxColliders[1]);
            itemText.enabled = true;
            StartCoroutine(Frame_4());
            StartCoroutine(EnabledText());
            frame_4 = false;
            interactItemCount--;
        }
        if (frame_5 && Input.GetKeyDown(KeyCode.E))
        {
            GameObject frame_5GameObject = GameObject.FindGameObjectWithTag("frame_5");
            BoxCollider[] frame_5BoxColliders = frame_5GameObject.GetComponents<BoxCollider>();
            Destroy(frame_5BoxColliders[1]);
            itemText.enabled = true;
            StartCoroutine(Frame_5());
            StartCoroutine(EnabledText());
            frame_5 = false;
            interactItemCount--;
        }
        if (door && hasKey && Input.GetKeyDown(KeyCode.E))
        {
            GameObject doorGameObject = GameObject.FindGameObjectWithTag("door");
            doorAudio.Play();
            uiKeyGameobject.SetActive(false);
            StartCoroutine(DoorAnim());
            doorGameObject.GetComponent<BoxCollider>().enabled = false;
            door = false;
        }
        if (!uiKeyGameobject.active && door && Input.GetKeyDown(KeyCode.E))
        {
            itemText.enabled = true;
            StartCoroutine(FindKey());
            StartCoroutine(EnabledText());
        }
        if (interactItemCount == 0 && !isEnd)
        {
            isEnd = true;
            StartCoroutine(EndText());
            exitDoorAnim.SetBool("open", true);
            exitDoorLight.enabled = true;
        }
        if (toy && Input.GetKeyDown(KeyCode.E))
        {
            itemText.enabled = true;
            StartCoroutine(Toys());
            StartCoroutine(EnabledText());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("clock"))
        {
            triggerClock = true;
        }
        if (other.gameObject.CompareTag("toy"))
        {
            toy = true;
        }
        if (other.gameObject.CompareTag("television"))
        {
            triggerTV = true;
        }
        if (other.gameObject.CompareTag("commode"))
        {
            commode = true;
        }
        if (other.gameObject.CompareTag("commode_1"))
        {
            commode_1 = true;
        }
        if (other.gameObject.CompareTag("frame_1"))
        {
            frame_1 = true;
        }
        if (other.gameObject.CompareTag("frame_2"))
        {
            frame_2 = true;
        }
        if (other.gameObject.CompareTag("frame_3"))
        {
            frame_3 = true;
        }
        if (other.gameObject.CompareTag("frame_4"))
        {
            frame_4 = true;
        }
        if (other.gameObject.CompareTag("frame_5"))
        {
            frame_5 = true;
        }
        if (other.gameObject.CompareTag("key"))
        {
            hasKey = true;
            Destroy(other.gameObject, 1f);
            StartCoroutine(Key());
        }
        if (other.gameObject.CompareTag("door"))
        {
            door = true;
        }
        if (other.gameObject.CompareTag("exit"))
        {
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("clock"))
        {
            triggerClock = false;
        }
        if (other.gameObject.CompareTag("toy"))
        {
            toy = false;
        }
        if (other.gameObject.CompareTag("television"))
        {
            triggerTV = false;
        }
        if (other.gameObject.CompareTag("commode"))
        {
            commode = false;
        }
        if (other.gameObject.CompareTag("commode_1"))
        {
            commode_1 = false;
        }
        if (other.gameObject.CompareTag("frame_1"))
        {
            frame_1 = false;
        }
        if (other.gameObject.CompareTag("frame_2"))
        {
            frame_2 = false;
        }
        if (other.gameObject.CompareTag("frame_3"))
        {
            frame_3 = false;
        }
        if (other.gameObject.CompareTag("frame_4"))
        {
            frame_4 = false;
        }
        if (other.gameObject.CompareTag("frame_5"))
        {
            frame_5 = false;
        }
        if (other.gameObject.CompareTag("door"))
        {
            door = false;
            //doorAnim.SetBool("open", false);
        }
    }

    IEnumerator EnabledText()
    {
        yield return new WaitForSeconds(9f);
        itemText.enabled = false;
        itemText.text = "";
    }

    IEnumerator TVTexts()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "Best times of my life.";
        StartCoroutine(TypeWrite());
    }
    IEnumerator ClockTexts()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "Looks like antique.";
        StartCoroutine(TypeWrite());
    }
    IEnumerator Toys()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "";
        StartCoroutine(TypeWrite());
    }
    IEnumerator FindKey()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "I think it's locked. The key must be somewhere around here. Let's find the key.";
        StartCoroutine(TypeWrite());
    }
    IEnumerator Frame_1()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "The last memory I remember of us.";
        StartCoroutine(TypeWrite());
    }
    IEnumerator Frame_2()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "I wish you were here.";
        StartCoroutine(TypeWrite());
    }

    IEnumerator Frame_3()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "I missed you so much.";
        StartCoroutine(TypeWrite());
    }

    IEnumerator Frame_4()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "My happiest memory.";
        StartCoroutine(TypeWrite());
    }IEnumerator Frame_5()
    {
        yield return new WaitForSeconds(2f);
        itemText.enabled = true;
        text = "The photo we took when my precious daughter turned 5 years old.";
        StartCoroutine(TypeWrite());
    }
    IEnumerator Commode()
    {
        yield return new WaitForSeconds(3f);
        itemText.enabled = true;
        text = "She was very grumpy while taking this photo.";
        StartCoroutine(TypeWrite());
    }
    IEnumerator Commode1()
    {
        yield return new WaitForSeconds(3f);
        itemText.enabled = true;
        text = "";
        StartCoroutine(TypeWrite());
        
    }
    IEnumerator CommodeAudio()
    {
        yield return new WaitForSeconds(.5f);
        shelfOpenAudio.Play();
    }
    IEnumerator Key()
    {
        yield return new WaitForSeconds(1f);
        keySound.Play();
        uiKeyGameobject.SetActive(true);
    }
    IEnumerator DoorAnim()
    {
        yield return new WaitForSeconds(.5f);
        doorAnim.SetBool("open", true);
    }
    IEnumerator EndText()
    {
        yield return new WaitForSeconds(10f);
        itemText.enabled = true;
        text = "I guess it's time to go now.";
        StartCoroutine(TypeWrite());
    }
    IEnumerator TypeWrite()
    {
        foreach (char i in text)
        {
            itemText.text += i.ToString();

            if (i.ToString() == ".") 
            { 
                yield return new WaitForSeconds(1); 
            }
            else 
            { 
                yield return new WaitForSeconds(delay); 
            }
        }
    }
}
