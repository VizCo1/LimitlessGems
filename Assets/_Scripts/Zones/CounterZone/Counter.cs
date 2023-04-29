using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter : QueueFlow
{
    [SerializeField] CounterZone zoneManager;
    [SerializeField] Transform exitSpot;
    float orderTime = 10f;
    float timeImprovement;
    float percentage = 0.05f;

    float probDoubleMoney = 0.05f;
    float initalProbDoubleMoney;

    private void Start()
    {
        initalProbDoubleMoney = probDoubleMoney;
        timeImprovement = orderTime * percentage;
    }

    Client actualClient;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            actualClient = other.GetComponent<Client>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence sequence = DOTween.Sequence().SetDelay(0.2f).Pause();

            sequence.Append(circleCanvas.AppearAndFill(orderTime)) // Client orders the gem
                    .AppendCallback(() =>
                    {
                        if (zoneManager.TryToProvideGemWithWorkZone(((int)actualClient.WantedGem()), this)) // If gem is available, then give gem. Else gem request saved 
                        {
                            // Give gem sequence
                            ReceiveGem((int)actualClient.WantedGem());
                        }
                    });
            
            sequence.Play();
        }
    }

    public Sequence ReceiveGem(int gem)
    {
        if (actualClient == null)
            return null;

        Client auxClient = actualClient;
        actualClient = null;

        return DOTween.Sequence()
            .SetDelay(0.25f)
            .Append(circleCanvas.AppearAndFill(1f))
            .AppendCallback(() => { GameController.SellGem(gem, IsMoneyDoubled()); auxClient.SetDestination(exitSpot.position); })
            .Append(DOVirtual.DelayedCall(0.5f, () => auxClient.GemDelivered()));
    }

    bool IsMoneyDoubled()
    {
        return probDoubleMoney < Random.Range(0f, 1);
    }

    public void UpdateAttributes(bool keyLevelReached)
    {
        if (keyLevelReached)
            probDoubleMoney += initalProbDoubleMoney;
        orderTime -= timeImprovement;
    }

    public void DoMajorUpgrade()
    {
        probDoubleMoney *= 2;
    }
}
