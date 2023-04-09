using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTable : MonoBehaviour
{
    [SerializeField] WorkZone zoneManager;
    [SerializeField] CircleCanvas circleCanvas;
    [SerializeField] Worker worker;

    float makeTime = 5f;

    Sequence CreateGemSequence(int gem)
    {
        Sequence s = DOTween.Sequence().Pause();
        s.Append(circleCanvas.AppearAndFill(makeTime));
        s.AppendCallback(() => worker.GoToNextPosition());

        return s;
    }

    void CreateGem()
    {
        int gem = Random.Range(0, 3);
        CreateGemSequence(gem).OnComplete(() => zoneManager.AddGemToInventory(0)).Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worker"))
        {
            other.transform.DOLookAt(transform.position, 1f, AxisConstraint.Y);
            
            if (zoneManager.CheckPendingRequests()) // There are pending requests
            {
                Debug.Log("A");
                CounterRequest request = zoneManager.pendingRequests.Dequeue();
                CreateGemSequence(request.gem).Append(request.counter.ReceivingGemSequence()).Play();
            }
            else // No pending requests
            {
                Debug.Log("B");
                CreateGem();
            }
        }
    }


}
