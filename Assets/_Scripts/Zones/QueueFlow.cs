using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class QueueFlow : PersistentMonoBehaviour
{
    [SerializeField] protected CircleCanvas circleCanvas;
    [SerializeField] protected GameObject[] visuals;
    [SerializeField] protected Transform exitSpot;
    [NonZSerialized] public AudioSource audioSource;
    [SerializeField] [HideInInspector] int visualIndex = 0;
    protected CustomQueue customQueue;

    protected bool placeOccupied = false;

    protected virtual void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
    }

   /* protected virtual void Start()
    {
        visuals[0].SetActive(false);
        visuals[visualIndex].SetActive(true);
    }*/

    public override void OnPostLoad()
    {
        visuals[0].SetActive(false);
        visuals[visualIndex].SetActive(true);
    }

    protected int VisualIndex() => visualIndex;

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
