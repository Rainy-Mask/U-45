using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private bool door1 = false;
    private bool door2 = false;
    private bool door3 = false;
    private bool door4 = false;
    private bool door5 = false;
    private bool door6 = false;
    private bool door7 = false;
    private bool door8 = false;
    private bool door9 = false;
    private bool door10 = false;
    private bool door11 = false;
    private bool door12 = false;

    [Header("Door Open Animations")]
    [SerializeField] private Animator door1Anim;
    [SerializeField] private Animator door2Anim;
    [SerializeField] private Animator door3Anim;
    [SerializeField] private Animator door4Anim;
    [SerializeField] private Animator door5Anim;
    [SerializeField] private Animator door6Anim;
    [SerializeField] private Animator door7Anim;
    [SerializeField] private Animator door9Anim;

    [Header("Door Open Sound")]
    [SerializeField] private AudioSource doorAudioSource;
    private void Update()
    {
        TriggerCommands();
    }

    void TriggerCommands()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (door1)
            {
                door1Anim.SetBool("open", true);
                GameObject door1Object = GameObject.FindGameObjectWithTag("door1");
                BoxCollider[] door1BoxColliders = door1Object.GetComponents<BoxCollider>();
                Destroy(door1BoxColliders[1]);
                doorAudioSource.Play();
                door1 = false;
            }
            if (door2)
            {
                door2Anim.SetBool("open", true);
                GameObject door2Object = GameObject.FindGameObjectWithTag("door2");
                BoxCollider[] door2BoxColliders = door2Object.GetComponents<BoxCollider>();
                Destroy(door2BoxColliders[1]);
                doorAudioSource.Play();
                door2 = false;
            }
            if (door3)
            {
                door3Anim.SetBool("open", true);
                GameObject door3Object = GameObject.FindGameObjectWithTag("door3");
                BoxCollider[] door3BoxColliders = door3Object.GetComponents<BoxCollider>();
                Destroy(door3BoxColliders[1]);
                doorAudioSource.Play();
                door3 = false;
            }
            if (door4)
            {
                door4Anim.SetBool("open", true);
                GameObject door4Object = GameObject.FindGameObjectWithTag("door4");
                BoxCollider[] door4BoxColliders = door4Object.GetComponents<BoxCollider>();
                Destroy(door4BoxColliders[1]);
                doorAudioSource.Play();
                door4 = false;
            }
            if (door5)
            {
                door5Anim.SetBool("open", true);
                GameObject door5Object = GameObject.FindGameObjectWithTag("door5");
                BoxCollider[] door5BoxColliders = door5Object.GetComponents<BoxCollider>();
                Destroy(door5BoxColliders[1]);
                doorAudioSource.Play();
                door5 = false;
            }
            if (door6)
            {
                door6Anim.SetBool("open", true);
                GameObject door6Object = GameObject.FindGameObjectWithTag("door6");
                BoxCollider[] door6BoxColliders = door6Object.GetComponents<BoxCollider>();
                Destroy(door6BoxColliders[1]);
                doorAudioSource.Play();
                door6 = false;
            }
            if (door7)
            {
                door7Anim.SetBool("open", true);
                GameObject door7Object = GameObject.FindGameObjectWithTag("door7");
                BoxCollider[] door7BoxColliders = door7Object.GetComponents<BoxCollider>();
                Destroy(door7BoxColliders[1]);
                doorAudioSource.Play();
                door7 = false;
            }
            if (door8)
            {
                door7Anim.SetBool("open", true);
                GameObject door8Object = GameObject.FindGameObjectWithTag("door8");
                BoxCollider[] door8BoxColliders = door8Object.GetComponents<BoxCollider>();
                Destroy(door8BoxColliders[1]);
                doorAudioSource.Play();
                door8 = false;
            }
            if (door9)
            {
                door9Anim.SetBool("open", true);
                GameObject door9Object = GameObject.FindGameObjectWithTag("door9");
                BoxCollider[] door9BoxColliders = door9Object.GetComponents<BoxCollider>();
                Destroy(door9BoxColliders[1]);
                doorAudioSource.Play();
                door9 = false;
            }
            if (door10)
            {
                door9Anim.SetBool("open", true);
                GameObject door10Object = GameObject.FindGameObjectWithTag("door10");
                BoxCollider[] door10BoxColliders = door10Object.GetComponents<BoxCollider>();
                Destroy(door10BoxColliders[1]);
                doorAudioSource.Play();
                door10 = false;
            }
            if (door11)
            {
                door9Anim.SetBool("open", true);
                GameObject door11Object = GameObject.FindGameObjectWithTag("door11");
                BoxCollider[] door11BoxColliders = door11Object.GetComponents<BoxCollider>();
                Destroy(door11BoxColliders[1]);
                doorAudioSource.Play();
                door11 = false;
            }
            if (door12)
            {
                door3Anim.SetBool("open", true);
                GameObject door12Object = GameObject.FindGameObjectWithTag("door12");
                BoxCollider[] door12BoxColliders = door12Object.GetComponents<BoxCollider>();
                Destroy(door12BoxColliders[1]);
                doorAudioSource.Play();
                door12 = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("door1"))
        {
            door1 = true;
        }
        if (other.gameObject.CompareTag("door2"))
        {
            door2 = true;
        }
        if (other.gameObject.CompareTag("door3"))
        {
            door3 = true;
        }
        if (other.gameObject.CompareTag("door4"))
        {
            door4 = true;
        }
        if (other.gameObject.CompareTag("door5"))
        {
            door5 = true;
        }
        if (other.gameObject.CompareTag("door6"))
        {
            door6 = true;
        }
        if (other.gameObject.CompareTag("door7"))
        {
            door7 = true;
        }
        if (other.gameObject.CompareTag("door8"))
        {
            door8 = true;
        }
        if (other.gameObject.CompareTag("door9"))
        {
            door9 = true;
        }
        if (other.gameObject.CompareTag("door10"))
        {
            door10 = true;
        }
        if (other.gameObject.CompareTag("door11"))
        {
            door11 = true;
        }
        if (other.gameObject.CompareTag("door12"))
        {
            door12 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("door1"))
        {
            door1 = false;
        }
        if (other.gameObject.CompareTag("door2"))
        {
            door2 = false;
        }
        if (other.gameObject.CompareTag("door3"))
        {
            door3 = false;
        }
        if (other.gameObject.CompareTag("door4"))
        {
            door4 = false;
        }
        if (other.gameObject.CompareTag("door5"))
        {
            door5 = false;
        }
        if (other.gameObject.CompareTag("door6"))
        {
            door6 = false;
        }
        if (other.gameObject.CompareTag("door7"))
        {
            door7 = false;
        }
        if (other.gameObject.CompareTag("door8"))
        {
            door8 = false;
        }
        if (other.gameObject.CompareTag("door9"))
        {
            door9 = false;
        }
        if (other.gameObject.CompareTag("door10"))
        {
            door10 = false;
        }
        if (other.gameObject.CompareTag("door11"))
        {
            door11 = false;
        }
        if (other.gameObject.CompareTag("door12"))
        {
            door12 = false;
        }
    }

}
