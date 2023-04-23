using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter : QueueFlow
{
    [SerializeField] CounterZone zoneManager;
    [SerializeField] Transform exitSpot;
    [SerializeField] float orderTime = 5f;

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

        GameController.EarnMoney(gem);

        Client auxClient = actualClient;
        actualClient = null;

        return DOTween.Sequence()
            .SetDelay(0.25f)
            .Append(circleCanvas.AppearAndFill(1f))
            .AppendCallback(() => auxClient.SetDestination(exitSpot.position))
            .Append(DOVirtual.DelayedCall(0.5f, () => auxClient.GemReceived()));
    }
}
