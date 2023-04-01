using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomQueueFlow : MonoBehaviour
{
    [Header("TEMPORARY, ONLY FOR TESTING")]
    [SerializeField] Worker worker;

    [SerializeField] CounterZone zoneManager;
    [SerializeField] CircleCanvas circleCanvas;
    CustomQueue customQueue;

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

            Tween t1 = circleCanvas.AppearAndFill();



            int gem;
            t1.OnComplete(() => gem = client.AskForGem()).Play();

            // -- Then
            //client.AskForGem();
            // -- Then
            //// circleCanvas del trabajador
            // -- Then
            //// Trabajador da la gema
            // -- Then
            //// Cliente empieza a recoger la gema (circleCanvas) y ese trabajador se dirige a la zona de descanso.

            // Cuando recibe la gema se va a su coche.
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
