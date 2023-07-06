using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSpawn : MonoBehaviour
{
    
    [SerializeField] private GameObject firstText;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private GameObject text5;
    [SerializeField] private GameObject text6;
    [SerializeField] private GameObject text7;
    [SerializeField] private AudioSource fxSound;
    [SerializeField] private AudioSource themeSound;
    private void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);
        text7.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("song"))
        {
            themeSound.Play();
        }
        if (other.gameObject.CompareTag("firstText"))
        {
            firstText.SetActive(false);
            fxSound.Play();
        }
        if (other.gameObject.CompareTag("text"))
        {
            text1.SetActive(true);
            fxSound.Play();
        }
        if (other.gameObject.CompareTag("text2"))
        {
            text2.SetActive(true);
            fxSound.Play();
        }
        if (other.gameObject.CompareTag("text3"))
        {
            text3.SetActive(true);
            fxSound.Play();
        }
        if (other.gameObject.CompareTag("text4"))
        {
            text4.SetActive(true);
            fxSound.Play();
        }
        if (other.gameObject.CompareTag("text5"))
        {
            text5.SetActive(true);
            fxSound.Play();
        }
        if (other.gameObject.CompareTag("text6"))
        {
            fxSound.Play();
            text6.SetActive(true);
        }
        if (other.gameObject.CompareTag("text7"))
        {
            text7.SetActive(true);
            fxSound.Play();
        }
        
        Destroy(other.gameObject);
    }
}
