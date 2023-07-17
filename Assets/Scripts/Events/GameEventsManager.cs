using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
   public static GameEventsManager instance { get; private set; }
   
   public GoldEvents goldEvents;
   public MiscEvents miscEvents;
   public QuestEvents questEvents;

   private void Awake()
   {
      if (instance != null)
      {
         Debug.LogError("Found more than one Game Events Manager in the scene");
      }

      instance = this;
      
      // initialize all events
      goldEvents = new GoldEvents();
      miscEvents = new MiscEvents();
      questEvents = new QuestEvents();
   }
}
