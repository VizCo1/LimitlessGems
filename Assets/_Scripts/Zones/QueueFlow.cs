using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueFlow : MonoBehaviour
{
    [SerializeField] protected CircleCanvas circleCanvas;
    [SerializeField] protected GameObject[] visuals;
    [SerializeField] protected Transform exitSpot;
    public AudioSource audioSource;
    protected int visualIndex = 0;
    protected CustomQueue customQueue;

    protected bool placeOccupied = false;

    protected virtual void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
    }

    protected virtual void Update()
    {
        if (customQueue.Count() != 0 && !placeOccupied)
        {
            placeOccupied = true;
            customQueue.Dequeue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        DOVirtual.DelayedCall(0.25f, () => placeOccupied = false);
    }

    public virtual void UpdateAttributes(bool keyLevelReached)
    {

    }

    protected void UpdateVisuals()
    {
        if (visualIndex >= visuals.Length)
        {
            Debug.LogError("ERROR: visual index out of length");
        }

        visuals[visualIndex++].SetActive(false);
        visuals[visualIndex].SetActive(true);
    }
}
