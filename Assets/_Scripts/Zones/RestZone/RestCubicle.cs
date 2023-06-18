using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using ZSerializer;

public class RestCubicle : QueueFlow
{
    [NonZSerialized][SerializeField] RestZone zoneManager;
    [NonZSerialized][SerializeField] float nextSpotDelay;
    Animator door;

    [HideInInspector][SerializeField] float restTime = 12f;
    float percentage = 0.02f;

    [HideInInspector][SerializeField] float probFasterRest = 0.05f;
    [HideInInspector][SerializeField] float initialProbFasterRest;
    float basicProbFasterRest;

    bool isFirstTime = false;
    bool workerInCubicle = false;

    protected /*override*/ void Start()
    {
        //base.Start();
        initialProbFasterRest = probFasterRest;
        basicProbFasterRest = initialProbFasterRest;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worker"))
        {
            Worker worker = other.GetComponent<Worker>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            workerInCubicle = true;

            ChangeDoorStatus();
            
            Sequence sq = DOTween.Sequence().SetDelay(0.2f)
                .Append(circleCanvas.AppearAndFill(RealRestTime()))
                .AppendCallback(() => workerInCubicle = false)
                .AppendCallback(() => audioSource.Play())
                .AppendCallback(() => ChangeDoorStatus())
                .Append(DOVirtual.DelayedCall(0.35f, () => worker.SetDestination(exitSpot.position)))
                .Append(DOVirtual.DelayedCall(nextSpotDelay, () => worker.GoToNextPosition()));
        }
    }

    private void MajorUpgradeChangeDoorStatus()
    {
        if (door == null)
            return;

        if (isFirstTime && workerInCubicle)
        {
            isFirstTime = false;
            door.Play("CloseDoorCubicle", 0, 1); // Jump to the end = door closed
        }
        else if (workerInCubicle)
        {
            door.SetTrigger("ChangeDoor");
        }
    }

    private void ChangeDoorStatus()
    {
        if (door == null)
            return;

        door.SetTrigger("ChangeDoor");
    }

    float RealRestTime()
    {
        float realRestTime;
        if (probFasterRest > Random.Range(0f, 1))
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
        DOVirtual.DelayedCall(0.5f, () => placeOccupied = false);
        //placeOccupied = false;
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
        MajorUpgradeChangeDoorStatus();

        initialProbFasterRest *= 1.75f;

        if (probFasterRest != basicProbFasterRest)
            probFasterRest *= 1.75f;
        else
            probFasterRest = initialProbFasterRest;

        Debug.Log("Probability of faster Rest: " + probFasterRest);
    }

    /*protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateVisuals();
            HandleDoorStatus();
            MajorUpgradeChangeDoorStatus();
        }
    }*/

    
    private void HandleDoorStatus()
    {
        if (workerInCubicle)
            isFirstTime = true;
        door = visuals[VisualIndex()].GetComponentInChildren<Animator>();
    }
}
