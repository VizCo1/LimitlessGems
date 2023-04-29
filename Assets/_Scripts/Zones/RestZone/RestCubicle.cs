using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCubicle : QueueFlow
{
    [SerializeField] RestZone zoneManager;
    float restTime = 12f;
    float timeImprovement;
    float timePercentage = 0.05f;

    float probSpeedBonus = 0.05f;
    float initialProbSpeedBonus;

    private void Start()
    {
        initialProbSpeedBonus = probSpeedBonus;
        timeImprovement = restTime * timePercentage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worker"))
        {
            Worker worker = other.GetComponent<Worker>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence sq = DOTween.Sequence().SetDelay(0.2f)
                .Append(circleCanvas.AppearAndFill(RealRestTime()))
                .AppendCallback(() => worker.GoToNextPosition());                
        }
    }

    float RealRestTime()
    {
        float realRestTime;
        if (probSpeedBonus < Random.Range(0f, 1))
            realRestTime = restTime * 0.5f;
        else
            realRestTime = restTime;

        return realRestTime;
    }

    private void OnTriggerExit(Collider other)
    {
        placeOccupied = false;
        other.GetComponent<Worker>().ChangeTag("WorkerExit");    
    }

    public void UpdateAttributes(bool keyLevelReached)
    {
        if (keyLevelReached)
            probSpeedBonus += initialProbSpeedBonus;
        restTime -= timeImprovement;
    }

    public void DoMajorUpdate()
    {
        probSpeedBonus *= 2;
    }
}
