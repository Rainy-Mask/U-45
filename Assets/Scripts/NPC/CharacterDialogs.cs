using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CharacterDialogs : MonoBehaviour
{
    [SerializeField] private NPC_Dialogue _npcDialogue;
    [SerializeField] private GameObject dialoguePanel;
    private npc1 _npc;
    private npc2 _npc2;
    private Remy _remy;
    private emily _emily;
    private Lily _lily;
    private Ashley _ashley;
    private Marcus _marcus;
    private Sarah _sarah;
    private JacksonDocBennett _jacksonDoc;

    private bool remyTrigger = false;
    private bool npc1Trigger = false;
    private bool npc2Trigger = false;
    private bool emilyTrigger = false;
    private bool lilyTrigger = false;
    private bool ashleyTrigger = false;
    private bool marcusTrigger = false;
    private bool sarahTrigger = false;
    private bool jacksonDocTrigger = false;

    private void Start()
    {
        _remy = GameObject.FindGameObjectWithTag("Remy").GetComponent<Remy>();
        _npc = GameObject.FindGameObjectWithTag("npc1").GetComponent<npc1>();
        _npc2 = GameObject.FindGameObjectWithTag("npc2").GetComponent<npc2>();
        _emily = GameObject.FindGameObjectWithTag("emily").GetComponent<emily>();
        _lily = GameObject.FindGameObjectWithTag("lily").GetComponent<Lily>();
        _ashley = GameObject.FindGameObjectWithTag("ashley").GetComponent<Ashley>();
        _marcus = GameObject.FindGameObjectWithTag("marcus").GetComponent<Marcus>();
        _sarah = GameObject.FindGameObjectWithTag("sarah").GetComponent<Sarah>();
        _jacksonDoc = GameObject.FindGameObjectWithTag("jacksonDoc").GetComponent<JacksonDocBennett>();
    }

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
        if (other.gameObject.CompareTag("npc2"))
        {
            npc2Trigger = true;
        }
        if (other.gameObject.CompareTag("emily"))
        {
            emilyTrigger = true;
        }
        if (other.gameObject.CompareTag("lily"))
        {
            lilyTrigger = true;
        }
        if (other.gameObject.CompareTag("ashley"))
        {
            ashleyTrigger = true;
        }
        if (other.gameObject.CompareTag("marcus"))
        {
            marcusTrigger = true;
        }
        if (other.gameObject.CompareTag("sarah"))
        {
            sarahTrigger = true;
        }
        if (other.gameObject.CompareTag("jacksonDoc"))
        {
            jacksonDocTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Array.Resize(ref _npcDialogue.lines, 0);
        /*if (other.gameObject.CompareTag("Remy"))
        {
            Array.Resize(ref _npcDialogue.lines, 0);
        }
        if (other.gameObject.CompareTag("npc1"))
        {
            Array.Resize(ref _npcDialogue.lines, 0);
        }
        if (other.gameObject.CompareTag("npc2"))
        {
            Array.Resize(ref _npcDialogue.lines, 0);
        }
        if (other.gameObject.CompareTag("emily"))
        {
            
        }*/
    }

    public void DialogCommands()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (remyTrigger)
            {
                _npcDialogue.lines = _remy.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                remyTrigger = false;
            }
            if (npc1Trigger)
            {
                _npcDialogue.lines = _npc.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                npc1Trigger = false;
            }
            if (npc2Trigger)
            {
                _npcDialogue.lines = _npc2.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                npc2Trigger = false;
            }
            if (emilyTrigger)
            {
                _npcDialogue.lines = _emily.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                emilyTrigger = false;
            }
            if (lilyTrigger)
            {
                _npcDialogue.lines = _lily.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                lilyTrigger = false;
            }
            if (ashleyTrigger)
            {
                _npcDialogue.lines = _ashley.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                ashleyTrigger = false;
            }
            if (marcusTrigger)
            {
                _npcDialogue.lines = _marcus.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                marcusTrigger = false;
            }
            if (sarahTrigger)
            {
                _npcDialogue.lines = _sarah.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                sarahTrigger = false;
            }
            if (jacksonDocTrigger)
            {
                _npcDialogue.lines = _jacksonDoc.dialogs;
                dialoguePanel.SetActive(true);
                _npcDialogue.StartDialog();
                jacksonDocTrigger = false;
            }
        }

    }
}
