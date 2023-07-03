using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private float hungerThreshold = 25f;
    [SerializeField] private float thirstThreshold = 30f;
    public bool IsDizzy { get; private set; }

    private float originalSpeed;
    private Coroutine dizzyCoroutine;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        characterMovement = GetComponent<CharacterMovement>();

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

    [SerializeField] private float dizzinessDuration = 5f;
    [SerializeField] private float dizzinessIntensity = 0.1f;
    [SerializeField] private float dizzinessRotationIntensity = 10f;

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
}