using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMusic characterMusic;

    [SerializeField] private float hungerThreshold = 25f;
    [SerializeField] private float thirstThreshold = 30f;
    public bool IsDizzy { get; private set; }

    private float originalSpeed;
    private Coroutine dizzyCoroutine;
    private float mentalHealthIncreaseRate = 1f; // Akıl sağlığı artış hızı
    
    [SerializeField] private Animator playCassette;
    [SerializeField] private TextMeshPro textMeshPro;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        characterMovement = GetComponent<CharacterMovement>();
        characterMusic = GetComponent<CharacterMusic>();

        if (playerStats == null)
        {
            Debug.LogError("PlayerStats component not found on the character!");
        }

        //originalSpeed = characterMovement.speed;
    }

    private void Update()
    {
        if (playerStats.hunger < hungerThreshold || playerStats.thirst < thirstThreshold)
        {
            ApplyEffects();
        }

        if (playerStats.hunger < 10f)
        {
            if (!IsDizzy)
            {
                dizzyCoroutine = StartCoroutine(StartDizzinessEffect());
            }
        }
        else
        {
            if (dizzyCoroutine != null)
            {
                StopCoroutine(dizzyCoroutine);
                IsDizzy = false;
            }
        }

        if (characterMusic != null && characterMusic.IsMusicPlaying)
        {
            IncreaseMentalHealth();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playCassette.SetBool("Play", true);
            if (characterMusic != null)
            {
                if (!characterMusic.IsMusicPlaying)
                {
                    int currentMusicIndex = characterMusic.PlayNextMusic();

                    switch (currentMusicIndex)
                    {
                        case 0:
                            textMeshPro.text = "Aksamlar Cokunce Bu Sensiz Sehre";
                            break;
                        case 1:
                            textMeshPro.text = "Sana Cikiyor Yollar";
                            break;
                        case 2:
                            textMeshPro.text = "Seni Severdim";
                            break;
                        case 3:
                            textMeshPro.text = "Yaramizda Kalsin";
                            break;
                        case 4:
                            textMeshPro.text = "Umit Ozdag - Anlayamazsin";
                            break;
                    }
                }
                else
                {
                    characterMusic.StopMusic();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            playCassette.SetBool("Play", false);
            if (characterMusic != null && characterMusic.IsMusicPlaying)
            {
                characterMusic.StopMusic();
            }
        }
    }




    private void ApplyEffects()
    {
        float speed = originalSpeed;
        float reducedSpeed = speed;

        if (playerStats.hunger < hungerThreshold)
        {
            reducedSpeed *= 0.75f; // %25 azaltma
        }

        if (playerStats.thirst < thirstThreshold)
        {
            reducedSpeed *= 0.8f; // %20 azaltma
        }

        if (playerStats.hunger < 15f && playerStats.thirst < 10f)
        {
            reducedSpeed = 1f;
        }

        characterMovement.speed = reducedSpeed;
    }

    [SerializeField] private float dizzinessDuration = 0f; // BURAYI TEKRAR AKTİFLEŞTİREBİLİRİZ!!!!!!
    [SerializeField] private float dizzinessIntensity = 0f;
    [SerializeField] private float dizzinessRotationIntensity = 0f;

    private IEnumerator StartDizzinessEffect()
    {
        IsDizzy = true;
        float elapsedTime = 0f;

        while (elapsedTime < dizzinessDuration)
        {
            float offsetX = Random.Range(-1f, 1f) * dizzinessIntensity;
            float offsetY = Random.Range(-1f, 1f) * dizzinessIntensity;
            float offsetRotationX = Random.Range(-1f, 1f) * dizzinessRotationIntensity;
            float offsetRotationY = Random.Range(-1f, 1f) * dizzinessRotationIntensity;

            transform.localPosition += new Vector3(offsetX, offsetY, 0f);
            transform.localRotation *= Quaternion.Euler(offsetRotationX, offsetRotationY, 0f);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        IsDizzy = false;
    }

    private void IncreaseMentalHealth()
    {
        const float mentalHealthIncreaseAmount = 1f; // Artırma miktarı

        // Akıl sağlığı seviyesini artır
        playerStats.sanity += mentalHealthIncreaseAmount * Time.deltaTime;
        playerStats.sanity = Mathf.Clamp(playerStats.sanity, 0f, 100f); // Akıl sağlığını 0 ile 100 arasında tut
    }




}
