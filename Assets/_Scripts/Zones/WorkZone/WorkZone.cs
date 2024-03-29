using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class WorkZone : Zone
{
    [NonZSerialized][HideInInspector] public Queue<CounterRequest> pendingRequestsGem0 = new();
    [NonZSerialized][HideInInspector] public Queue<CounterRequest> pendingRequestsGem1 = new();
    [NonZSerialized][HideInInspector] public Queue<CounterRequest> pendingRequestsGem2 = new();

    Queue<CounterRequest>[] queues;
    
    public List<WorkTable> tables { get; private set; } = new();

    private void Awake()
    {
        MaxActiveSpots = transform.GetChild(SLOTS_INDEX).childCount;

        for (int i = 0; i < MaxActiveSpots; i++)
        {
            GameObject workTable = transform.GetChild(SLOTS_INDEX).GetChild(i).gameObject;
            tables.Add(workTable.GetComponent<WorkTable>());
        }
    }

    void Start()
    {
        queues = new Queue<CounterRequest>[] { pendingRequestsGem0, pendingRequestsGem1, pendingRequestsGem2 };

        for (int i = 0; i < ActiveSpots; i++)
        {
            GameObject workTable = transform.GetChild(SLOTS_INDEX).GetChild(i).gameObject;
            workTable.SetActive(true);
        }
    }

    public void AddTable()
    {
        GameObject newSlot = tables[ActiveSpots++].gameObject;
        newSlot.SetActive(true);
    }

    public bool TryProvideGem(int gem, Counter counter)
    {
        if (GameController.gemsQuantity[gem] != 0) // We have that gem
        {
            //Debug.Log("Gem is available, no need to create it");
            GameController.UpdateGemQuantity(gem, -1);
            return true;
        }
        else // We don't have that gem
        {
            //Debug.Log("New gem request created --> GEM: " + gem + "\n");
            switch (gem)
            {
                case 0:
                    pendingRequestsGem0.Enqueue(new(counter, gem));
                    break;
                case 1:
                    pendingRequestsGem1.Enqueue(new(counter, gem));
                    break;
                case 2:
                    pendingRequestsGem2.Enqueue(new(counter, gem));
                    break;
            }
            
            return false;
        }
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        agent.GoToNextPosition();
    }

    public void AddGemToInventory(int gem)
    {
        //Debug.Log("Gem " + gem + " added to inventory");
        GameController.UpdateGemQuantity(gem, 1);
    }

    public bool CheckForPendingRequests()
    {
        return pendingRequestsGem0.Count + pendingRequestsGem1.Count + pendingRequestsGem2.Count > 0;
    }

    public CounterRequest GetRandomPendingRequest()
    {
        List<int> indicesWithRequests = new();

        if (pendingRequestsGem0.Count > 0)
        {
            indicesWithRequests.Add(0);
        }

        if (pendingRequestsGem1.Count > 0)
        {
            indicesWithRequests.Add(1);
        }

        if (pendingRequestsGem2.Count > 0)
        {
            indicesWithRequests.Add(2);
        }

        return queues[ indicesWithRequests[Random.Range(0, indicesWithRequests.Count)] ].Dequeue();
    }

    public Queue<CounterRequest> GetPendingRequestsOf(int gem)
    {
        return queues[gem];
    }

    public bool AnyRequestForThisGem(int gem)
    {
        return queues[gem].Count != 0;
    }

    public void MajorUpgrade()
    {
        GameController.IncreaseGemsPrices(10f);
        foreach (WorkTable wt in tables)
        {
            wt.DoMajorUpgrade();
        }
    }
}
