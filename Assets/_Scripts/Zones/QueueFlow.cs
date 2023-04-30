using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueFlow : MonoBehaviour
{
    [SerializeField] protected CircleCanvas circleCanvas;
    protected CustomQueue customQueue;

    protected bool placeOccupied = false;

    protected virtual void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
    }

    private void Update()
    {
        if (customQueue.Count() != 0 && !placeOccupied)
        {
            placeOccupied = true;
            customQueue.Dequeue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        placeOccupied = false;
    }

    public virtual void UpdateAttributes(bool keyLevelReached)
    {

    }
}
