using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter : MonoBehaviour
{
    [SerializeField] CounterZone zoneManager;
    [SerializeField] CircleCanvas circleCanvas;
    CustomQueue customQueue;

    float orderTime = 5f;
    bool counterOccupied = false;

    private void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
        //customQueue.Dequeue();
    }


    private void Update()
    {
        if (customQueue.Count() != 0 && !counterOccupied)
        {
            counterOccupied = true;
            customQueue.Dequeue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Client client = other.GetComponent<Client>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence mySequence = DOTween.Sequence().Pause();

            mySequence.Append(circleCanvas.AppearAndFill(orderTime))
                .AppendCallback( () => zoneManager.CommunicateWithWorkZone(client.WantedGem() ))
                .Append(circleCanvas.AppearAndFill(1f))
                .AppendCallback( () => client.ReceiveGem() )
            .Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counterOccupied = false;
        }
    }
}
