using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ZSerializer;

public class Counter : QueueFlow
{
    [NonZSerialized][SerializeField] CounterZone zoneManager;
    [NonZSerialized][SerializeField] ParticleSystem moneyParticles;
    [NonZSerialized][SerializeField] ParticleSystem doubledMoneyParticles;
    float percentage = 0.02f;

    [HideInInspector][SerializeField] float orderTime = 12f;
    [HideInInspector][SerializeField] float probDoubleMoney = 0.05f;
    [HideInInspector][SerializeField] float initalProbDoubleMoney;

    float basicProbDoubleMoney;

    protected /*override*/ void Start()
    {
        //base.Start();
        initalProbDoubleMoney = probDoubleMoney;
        basicProbDoubleMoney = initalProbDoubleMoney;
    }

    /*protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateVisuals();
            DoMajorUpgrade();
        }
    }*/


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
            .AppendCallback(() => 
            {
                bool doubleTheIncome = IsMoneyDoubled();
                if (doubleTheIncome)
                {
                    doubledMoneyParticles.Play();
                }
                else
                {
                    moneyParticles.Play();
                }
                GameController.SellGem(gem, doubleTheIncome); 
                auxClient.SetDestination(exitSpot.position); 
            })
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
