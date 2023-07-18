using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
   [SerializeField] private int startingGold = 5;

   public int currentGold { get; private set; }

   private void Awake()
   {
      currentGold = startingGold;
   }
   private void OnEnable()
   {
      GameEventsManager.instance.goldEvents.onGoldGained += GoldGained;
   }

   private void OnDisable()
   {
      GameEventsManager.instance.goldEvents.onGoldGained -= GoldGained;
   }

   private void Start()
   {
      GameEventsManager.instance.goldEvents.GoldChange(currentGold);
   }

   private void GoldGained(int gold)
   {
      currentGold += gold;
      GameEventsManager.instance.goldEvents.GoldChange(currentGold);
   }
}
