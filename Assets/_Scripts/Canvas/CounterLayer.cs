using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterLayer : Layer
{
    [SerializeField] CounterZone counterZone;
    
    protected override void InitializeObjectsInLine()
    {
        activeSpots = counterZone.ActiveSpots();
        maxActiveSpots = counterZone.maxActiveSpots;

        for (int i = 0; i < counterZone.counters.Count; i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(false);
            objectInLines[i].index = i;
        }

        for (int i = 0; i < activeSpots; i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(true);
        }
    }

    public override void Init()
    {
        base.Init();

    }
    public override void End()
    {

        base.End();
    }

    public void UpdateAttributesAndCheckCosts(int index)
    {
        UpdateAndCheck();
        counterZone.counters[index].UpdateAttributes();
    }

    public void UnlockCounter()
    {      
        activeSpots++;
        unlockCostText.text = (BigDouble.Parse(unlockCostText.text) * 2).ToString();
        GameController.money -= BigDouble.Parse(unlockCostText.text);
        UpdateAndCheck();
        counterZone.AddQueue();
    }

    void UpdateAndCheck()
    {
        CanvasManager.UpdateMoney();
        CheckButtons();
    }
}
