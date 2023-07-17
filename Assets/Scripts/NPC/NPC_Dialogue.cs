using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{ 
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;

    public int index;
    private void Start()
    {
        dialogueText.text = string.Empty;
        StartDialog();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (dialogueText.text == lines[index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];   
            }
        }
    }
    public void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) // kelimeleri harf harf al
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        NextLine();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            dialogueText.text = string.Empty;
            Array.Resize(ref lines, 0);
        }
    }
} 
