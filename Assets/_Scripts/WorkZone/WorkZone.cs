using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorkZone : Zone
{
    int[] gemsQuantity = new int[3] { 0, 0, 0 };
    readonly List<WorkTable> tables = new();

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            tables.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<WorkTable>());
    }

    public void ProvideGem(int gem, ref Sequence sequence)
    {
        if (gemsQuantity[gem] != 0) // We have that gem, no hace falta un trabajador
        {
            gemsQuantity[gem]--;
            // le damos la gema al cliente
        }
        else // We don't, hace falta un trabajador
        {
            FindFreeWorkTable(ref sequence);
        }
    }


    void FindFreeWorkTable(ref Sequence sequence)
    {
        foreach (WorkTable table in tables)
        {
            if (table.IsWorkerFree())
            {
                Worker worker = table.CreateGem(ref sequence);
                //MoveAgentToSpot(worker);
            }
        }
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        /*CustomQueue bestQueue = priorityQueue.Peek();
        priorityQueue.IncreasePriority(bestQueue);
        bestQueue.Enqueue(agent);*/
    }
}
