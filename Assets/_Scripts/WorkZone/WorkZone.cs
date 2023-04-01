using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorkZone : Zone
{
    int[] gemsQuantity = new int[3] { 0, 0, 0 };

    List<WorkTable> tables = new();

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            tables.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<WorkTable>());
    }

    public void ProvideGem(int gem)
    {
        if (gemsQuantity[gem] != 0) // We have that gem
        {
            gemsQuantity[gem]--;
            // le damos la gema al cliente
        }
        else // We don't
        {
            //Worker freeWorker = GetFreeWorker();
        }
    }


    Worker GetFreeWorker()
    {
        /*
        bool workerFound = false;

        while (!workerFound)
        {
            foreach (WorkTable table in tables)
            {
                Worker worker = table.GetWorker();
                if (worker != null)
                    return worker;
            }
        }*/

        return null;
    }
}
