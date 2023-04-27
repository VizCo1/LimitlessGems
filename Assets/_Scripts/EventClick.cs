using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] CanvasManager canvasManager;
    [SerializeField] int index;

    public void OnPointerClick(PointerEventData eventData)
    {
        canvasManager.OpenLayer(index);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
