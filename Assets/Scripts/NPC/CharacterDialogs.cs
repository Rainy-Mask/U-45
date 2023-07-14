using System;
using UnityEngine;

public class CharacterDialogs : MonoBehaviour
{/*
    [SerializeField] private NPC_Dialogue _npcDialogue;
    [SerializeField] private GameObject dialoguePanel;
    private npc1 _npc;

    private bool remyTrigger = false;
    private bool npc1Trigger = false;


    private void Update()
    {
        DialogCommands();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Remy")) 
        {
            remyTrigger = true; 
        }
        if (other.gameObject.CompareTag("npc1")) 
        {
            npc1Trigger = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Remy"))
        {
            remyTrigger = false;    
            dialoguePanel.SetActive(false);
        }
        if (other.gameObject.CompareTag("npc1"))
        {
            npc1Trigger = false;    
            dialoguePanel.SetActive(false);
        }
    }

    public void DialogCommands()
    {
        if (remyTrigger && Input.GetKeyDown(KeyCode.E))
        {
            _npc = GameObject.FindGameObjectWithTag("Remy").GetComponent<npc1>();
            dialoguePanel.SetActive(true);
            _npcDialogue.lines = _npc.dialogs;
            _npcDialogue.dialogueText.text = _npcDialogue.lines[_npcDialogue.index];
        }
        if (npc1Trigger && Input.GetKeyDown(KeyCode.E))
        {
            _npc = GameObject.FindGameObjectWithTag("npc1").GetComponent<npc1>();
            dialoguePanel.SetActive(true);
            _npcDialogue.lines = _npc.dialogs;
            _npcDialogue.dialogueText.text = _npcDialogue.lines[_npcDialogue.index];
        }
    }*/

    [SerializeField] private NPC_Dialogue _npcDialogue;
    [SerializeField] private GameObject dialoguePanel;
    private npc1 _npc;

    private bool remyTrigger = false;
    private bool npc1Trigger = false;

    private void Update()
    {
        DialogCommands();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Remy"))
        {
            remyTrigger = true;
        }
        if (other.gameObject.CompareTag("npc1"))
        {
            npc1Trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Remy"))
        {
            remyTrigger = false;
            dialoguePanel.SetActive(false);
        }
        if (other.gameObject.CompareTag("npc1"))
        {
            npc1Trigger = false;
            dialoguePanel.SetActive(false);
        }
    }

    public void DialogCommands()
    {
        if (remyTrigger && Input.GetKeyDown(KeyCode.E))
        {
            _npc = GameObject.FindGameObjectWithTag("Remy").GetComponent<npc1>();
            if (_npc != null && _npc.dialogs != null && _npc.dialogs.Length > 0)
            {
                dialoguePanel.SetActive(true);
                _npcDialogue.lines = _npc.dialogs;
                _npcDialogue.index = 0;
                _npcDialogue.StartDialog();
            }
            else
            {
                Debug.LogWarning("Remy NPC component or dialogs array is missing.");
            }
        }
        else if (npc1Trigger && Input.GetKeyDown(KeyCode.E))
        {
            _npc = GameObject.FindGameObjectWithTag("npc1").GetComponent<npc1>();
            if (_npc != null && _npc.dialogs != null && _npc.dialogs.Length > 0)
            {
                dialoguePanel.SetActive(true);
                _npcDialogue.lines = _npc.dialogs;
                _npcDialogue.index = 0;
                _npcDialogue.StartDialog();
            }
            else
            {
                Debug.LogWarning("npc1 NPC component or dialogs array is missing.");
            }
        }
    }
}
