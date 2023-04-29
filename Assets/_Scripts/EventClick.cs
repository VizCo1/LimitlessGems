using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class EventClick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] CanvasManager canvasManager;
    [SerializeField] int index;

    float maxTime = 0.5f;
    float maxDistance = 20f;

    Vector2 downPos;
    Vector2 upPos;

    bool canOpen;

    Tween timer;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (timer.IsActive())
            timer.Kill();

        canOpen = true;

        downPos = eventData.position;
        timer = DOVirtual.DelayedCall(maxTime, () => canOpen = false).OnComplete(() => { }/*Debug.Log("TIME OUT")*/);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        upPos = eventData.position;

        //Debug.Log("Distance: " + Vector2.Distance(upPos, downPos));

        if (Vector2.Distance(upPos, downPos) > maxDistance)       
            canOpen = false;
        else if (canOpen)
            canvasManager.OpenLayer(index);      
    }
}
