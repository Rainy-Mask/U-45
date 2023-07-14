using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{ /*
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
    void StartDialog()
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
    }*/

    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;
    public float autoSpeed; // Otomatik geçiþ hýzý

    private int currentIndex;
    private bool isTyping;
    private Coroutine typingCoroutine;

    public int index 
    {
        get { return currentIndex; }
        set { currentIndex = value; }
    }

    private void Start()
    {
        dialogueText.text = string.Empty;
        currentIndex = 0;
        isTyping = false;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                CompleteLine();
            }
            else
            {
                NextLine();
            }
        }
    }

    public void StartDialog()
    {
        if (lines.Length > 0)
        {
            currentIndex = 0;
            isTyping = true;
            dialogueText.text = string.Empty;
            typingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            EndDialog();
        }
    }

    IEnumerator TypeLine()
    {
        string line = lines[currentIndex];
        int charIndex = 0;
        while (charIndex < line.Length)
        {
            dialogueText.text += line[charIndex];
            charIndex++;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(autoSpeed);
        NextLine();
    }

    void CompleteLine()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = lines[currentIndex];
            isTyping = false;
        }
    }

    void NextLine()
    {
        if (isTyping)
        {
            CompleteLine();
        }
        else
        {
            currentIndex++;
            if (currentIndex < lines.Length)
            {
                isTyping = true;
                dialogueText.text = string.Empty;
                typingCoroutine = StartCoroutine(TypeLine());
            }
            else
            {
                EndDialog();
            }
        }
    }

    void EndDialog()
    {
        gameObject.SetActive(false);
        dialogueText.text = string.Empty;
        lines = new string[0];
    }
} 
