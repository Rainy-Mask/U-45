using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Coin : MonoBehaviour
{
  [Header("Config")] 
  
  [SerializeField] private float respawnTimeSeconds = 8;

  [SerializeField] private int goldGained = 1;

  private BoxCollider boxCollider;

  private SpriteRenderer visual;

  private void Awake()
  {
    boxCollider = GetComponent<BoxCollider>();
    visual = GetComponentInChildren<SpriteRenderer>();
  }

  private void CollectCoin()
  {
    boxCollider.enabled = false;
    visual.gameObject.SetActive(false);
    GameEventsManager.instance.goldEvents.GoldGained(goldGained);
    GameEventsManager.instance.miscEvents.CoinCollected();
    StopAllCoroutines();
    StartCoroutine(RespawnAfterTime());
  }

  private IEnumerator RespawnAfterTime()
  {
    yield return new WaitForSeconds(respawnTimeSeconds);
    boxCollider.enabled = true;
    visual.gameObject.SetActive(true);
  }

  private void OnTriggerEnter(Collider otherCollider)
  {
    if (otherCollider.CompareTag("Player"))
    {
      CollectCoin();
    }
  }
}
