using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCubicle : QueueFlow
{
    [SerializeField] RestZone zoneManager;
    Animator door;
    float restTime = 12f;
    float percentage = 0.02f;

    float probFasterRest = 0.05f;
    float initialProbFasterRest;
    float basicProbFasterRest;

    protected override void Awake()
    {
        base.Awake();
        initialProbFasterRest = probFasterRest;
        basicProbFasterRest = initialProbFasterRest;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worker"))
        {
            Worker worker = other.GetComponent<Worker>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence sq = DOTween.Sequence().SetDelay(0.2f)
                .AppendCallback(() => ChangeDoorStatus())
                .Append(circleCanvas.AppearAndFill(RealRestTime()))
                .AppendCallback(() => worker.SetDestination(exitSpot.position))
                .Append(DOVirtual.DelayedCall(0.2f, () => ChangeDoorStatus()))
                .Append(DOVirtual.DelayedCall(0.5f, () => worker.GoToNextPosition()));
        }
    }

    private void ChangeDoorStatus()
    {
        if (door != null)
        {
            door.SetTrigger("ChangeDoor");
        }
    }

    float RealRestTime()
    {
        float realRestTime;
        if (probFasterRest < Random.Range(0f, 1))
        {
            realRestTime = restTime * 0.5f;
            Debug.Log("FASTER REST!!!");
        }
        else
            realRestTime = restTime;

        return realRestTime;
    }

    private void OnTriggerExit(Collider other)
    {
        placeOccupied = false;
        other.GetComponent<Worker>().ChangeTag("WorkerExit");    
    }

    public override void UpdateAttributes(bool keyLevelReached)
    {
        if (keyLevelReached)
            probFasterRest += initialProbFasterRest;
        restTime -=  restTime * percentage;

        Debug.Log("Probability faster Rest: " + probFasterRest);
        Debug.Log("Rest Time: " + restTime);

    }

    public void DoMajorUpdate()
    {
        UpdateVisuals();
        HandleDoorStatus();
        

        initialProbFasterRest *= 1.75f;

        if (probFasterRest != basicProbFasterRest)
            probFasterRest *= 1.75f;
        else
            probFasterRest = initialProbFasterRest;

        Debug.Log("Probability of faster Rest: " + probFasterRest);
    }

    private void HandleDoorStatus()
    {
        door = visuals[visualIndex].GetComponentInChildren<Animator>();
    }
}
