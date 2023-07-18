using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Meeting : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI meetingText;
    [SerializeField] private TextMeshProUGUI title;

    [SerializeField] private TextMeshProUGUI HeyMicheal;
    [SerializeField] private TextMeshProUGUI Sarah;
    [SerializeField] private TextMeshProUGUI Jackson;
    [SerializeField] private TextMeshProUGUI end;
    [SerializeField] private TextMeshProUGUI Marcus;
    [SerializeField] private TextMeshProUGUI Emily;
    [SerializeField] private TextMeshProUGUI Lily;
    [SerializeField] private TextMeshProUGUI Ashley;

    [SerializeField] private GameObject meetingPanel;
    [SerializeField] private GameObject meetingTitle;
    [SerializeField] private TextMeshProUGUI meetingTxt;
    [SerializeField] private int meetingCount = 5;
    private CharacterDialogs dialogs;
    private Meeting mtng;

    private void Start()
    {
        dialogs = GetComponent<CharacterDialogs>();
        mtng = GetComponent<Meeting>();
        mtng.enabled = false;
    }
    private void Update()
    {
        End();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("meeting"))
        {
            mtng.enabled = true;
            meetingPanel.SetActive(true);
            meetingTitle.SetActive(true);
            meetingText.enabled = true;
            meetingTxt.enabled = true;
            Invoke("SetActiveFalse", 3f);
        }

        if (other.gameObject.CompareTag("npc1") || other.gameObject.CompareTag("Remy") || other.gameObject.CompareTag("npc2") ||
            other.gameObject.CompareTag("emily") || other.gameObject.CompareTag("jackson") || other.gameObject.CompareTag("ashley") ||
            other.gameObject.CompareTag("marcus") || other.gameObject.CompareTag("lily") || other.gameObject.CompareTag("sarah") || other.gameObject.CompareTag("jacksonDoc"))
        {
           
            if (other.gameObject.CompareTag("npc1"))
            {
                end.enabled = true;
                dialogs.npc1Trigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("Remy"))
            {
                HeyMicheal.enabled = true;
                dialogs.remyTrigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("npc2"))
            {
                dialogs.npc2Trigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("emily"))
            {
                Emily.enabled = true;   
                dialogs.emilyTrigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("jacksonDoc"))
            {
                Jackson.enabled = true;
                dialogs.jacksonDocTrigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("ashley"))
            {
                Ashley.enabled = true;  
                dialogs.ashleyTrigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("marcus"))
            {
                Marcus.enabled = true;  
                dialogs.marcusTrigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("lily"))
            {
                Lily.enabled = true;    
                dialogs.lilyTrigger = true;
                dialogs.Update();
                Count();
            }
            if (other.gameObject.CompareTag("sarah"))
            {
                Sarah.enabled = true;
                dialogs.sarahTrigger = true;
                dialogs.Update();
                Count();

            }
            Destroy(other.gameObject);

        }
    }
    void SetActiveFalse()
    {
        meetingTitle.SetActive(false);
    }
    void End()
    {
        if (meetingCount == 0 || meetingCount < 0)
        {
            meetingText.enabled = false;
            meetingTitle.SetActive(true);
            title.text = "Mission Completed";
            Invoke("Finish", 3f);
        }
    }

    void Finish()
    {
        meetingPanel.SetActive(false);
        meetingTitle.SetActive(false);
        meetingTxt.enabled = false;
        mtng.enabled = false;
        Destroy(mtng);
        Sarah.enabled = false;
        Lily.enabled = false;
        Ashley.enabled = false;
        Jackson.enabled = false;
        Emily.enabled = false;
        HeyMicheal.enabled = false; 
        end.enabled = false;
    }
    void Count()
    {
        meetingCount--;
        meetingText.text = meetingCount.ToString();
        meetingText.enabled = true;
    }
}
