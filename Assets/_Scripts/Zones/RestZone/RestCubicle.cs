using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCubicle : QueueFlow
{
    [SerializeField] RestZone zoneManager;
    [SerializeField] float nextSpotDelay;
    public Animator door;
    float restTime = 12f;
    float percentage = 0.02f;

    float probFasterRest = 0.05f;
    float initialProbFasterRest;
    float basicProbFasterRest;

    string nextTrigger;

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

            ChangeDoorStatus();
            
            Sequence sq = DOTween.Sequence().SetDelay(0.2f)
                //.AppendCallback(() => ChangeDoorStatus())
                .Append(circleCanvas.AppearAndFill(RealRestTime()))
                .AppendCallback(() => ChangeDoorStatus())
                .Append(DOVirtual.DelayedCall( 1f, () => worker.SetDestination(exitSpot.position) ) )
                .Append(DOVirtual.DelayedCall(nextSpotDelay, () => worker.GoToNextPosition()));
        }
    }

    private void ChangeDoorStatus()
    {
        // WORK TO BE DONE!!!!
        if (nextTrigger != null) 
        {
            door.SetTrigger(nextTrigger);
            nextTrigger = null;
        }
        else if (door != null)
        {
            door.SetTrigger("ChangeDoor");
        }
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

        initialProbFasterRest *= 1.75f;

        if (probFasterRest != basicProbFasterRest)
            probFasterRest *= 1.75f;
        else
            probFasterRest = initialProbFasterRest;

        Debug.Log("Probability of faster Rest: " + probFasterRest);
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateVisuals();
            HandleDoorStatus();
        }
    }

    
    private void HandleDoorStatus()
    {
        door = visuals[visualIndex].GetComponentInChildren<Animator>();

        if (placeOccupied)
        {
            nextTrigger = "FirstOpening";
        }
        else
        {
            nextTrigger = null;
            door.SetTrigger("FirstOpening");
        }
    }
}
