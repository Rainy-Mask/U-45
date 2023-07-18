using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinsQuestStep : QuestStep
{
  private int coinsCollected = 0;

  private int coinsToComplate = 5;

  private void OnEnable()
  {
    GameEventsManager.instance.miscEvents.onCoinCollected += CoinCollected;
  }

  private void OnDisable()
  {
    GameEventsManager.instance.miscEvents.onCoinCollected -= CoinCollected;
  }

  private void CoinCollected()
  {
    if (coinsCollected < coinsToComplate)
    {
      coinsCollected++;
      UpdateState();
    }

    if (coinsCollected >= coinsToComplate)
    {
      FinishQuestStep();
    }
  }

  private void UpdateState()
  {
    string state = coinsCollected.ToString();
    ChangeState(state);
  }

  protected override void SetQuestStepState(string state)
  {
    this.coinsCollected = System.Int32.Parse(state);
    UpdateState();
  }
}
