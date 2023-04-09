using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class WorkZone : Zone
{
    int[] gemsQuantity = new int[3] { 0, 0, 0 };
    List<WorkTable> tables = new();

    [HideInInspector] public Queue<CounterRequest> pendingRequests = new();

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            tables.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<WorkTable>());
    }

    public bool TryProvideGem(int gem, Counter counter)
    {
        if (gemsQuantity[gem] != 0) // We have that gem
        {
            Debug.Log("Gem is available, no need to create it");
            gemsQuantity[gem]--;
            return true;
        }
        else // We don't have that gem
        {
            Debug.Log("New gem request created");
            pendingRequests.Enqueue(new(counter, gem));
            return false;
        }
    }

    public bool CheckPendingRequests()
    {
        if (pendingRequests.Count == 0)
            return false;

        return true;
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        agent.GoToNextPosition();
    }

    public void AddGemToInventory(int gem)
    {
        Debug.Log("Gem " + gem + " added to inventory");
        gemsQuantity[gem]++;
    }
}
