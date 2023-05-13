using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTable : MonoBehaviour
{
    [SerializeField] WorkZone zoneManager;
    [SerializeField] CircleCanvas circleCanvas;
    [SerializeField] Worker worker;
    [SerializeField] GameObject[] visuals;
    int visualIndex = 0;

    float productionTime = 2f; // 12f
    float percentage = 0.02f;

    Sequence CreateGemSequence()
    {
        return DOTween.Sequence()
            .Append(circleCanvas.AppearAndFill(productionTime))
            .AppendCallback(() => worker.GoToNextPosition())
            .SetDelay(0.2f);
    }

    void CreateGem()
    {
        int gem = Random.Range(0, 3);
        CreateGemSequence()
            .OnComplete(() =>
            {
                if (zoneManager.AnyRequestForThisGem(gem))
                {                   
                    zoneManager.GetPendingRequestsOf(gem).Dequeue().counter.ReceiveGem(gem);
                }
                else
                {
                    zoneManager.AddGemToInventory(gem);
                }
            })
            .Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == worker.gameObject)
        {
            other.transform.DOLookAt(transform.position, 1f, AxisConstraint.Y);
            worker.ChangeTag("Worker");

            if (zoneManager.CheckForPendingRequests()) // There are pending requests
            {
                CounterRequest counterRequest = zoneManager.GetRandomPendingRequest();
                CreateGemSequence().Append(counterRequest.counter.ReceiveGem(counterRequest.gem));
            }
            else // No pending requests
            {
                CreateGem();
            }
        }
    }

    public void UpdateAttributes()
    {
        productionTime -= productionTime * percentage;
        GameController.IncreaseGemsPrices(1.1f);
        Debug.Log("ProductionTime: " + productionTime);
    }

    public void DoMajorUpgrade()
    {
        if (visualIndex >= visuals.Length)
        {
            Debug.LogError("ERROR: visual index out of length");
        }

        visuals[visualIndex++].SetActive(false);
        visuals[visualIndex].SetActive(true);
    }
}
