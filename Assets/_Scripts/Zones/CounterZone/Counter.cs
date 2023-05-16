using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter : QueueFlow
{
    [SerializeField] CounterZone zoneManager;
    [SerializeField] ParticleSystem moneyParticles;
    float orderTime = 12f;
    float percentage = 0.02f;

    float probDoubleMoney = 0.05f;
    float initalProbDoubleMoney;

    float basicProbDoubleMoney;

    protected override void Awake()
    {
        base.Awake();

        initalProbDoubleMoney = probDoubleMoney;
        basicProbDoubleMoney = initalProbDoubleMoney;
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
                        if (zoneManager.TryToProvideGemWithWorkZone((int)actualClient.WantedGem(), this)) // If gem is available, then give gem. Else gem request saved 
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
            .AppendCallback(() => moneyParticles.Play())
            .AppendCallback(() => { GameController.SellGem(gem, IsMoneyDoubled()); auxClient.SetDestination(exitSpot.position); })
            .Append(DOVirtual.DelayedCall(0.5f, () => auxClient.GemDelivered()));
    }

    bool IsMoneyDoubled()
    {
        return probDoubleMoney > Random.Range(0f, 1);
    }

    public override void UpdateAttributes(bool keyLevelReached)
    {
        if (keyLevelReached)
            probDoubleMoney += initalProbDoubleMoney;
        orderTime -= orderTime * percentage;

        //Debug.Log("Probability double money: " + probDoubleMoney);
        //Debug.Log("Current orderTime: " + orderTime);
    }

    public void DoMajorUpgrade()
    {
        UpdateVisuals();

        initalProbDoubleMoney *= 1.75f;

        if (probDoubleMoney != basicProbDoubleMoney)
            probDoubleMoney *= 1.75f;
        else
            probDoubleMoney = initalProbDoubleMoney;

        //Debug.Log("Probability double money: " + initalProbDoubleMoney);
    }
}
