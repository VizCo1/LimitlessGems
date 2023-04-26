using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterLayer : Layer
{
    [SerializeField] CounterZone cZone;
    [SerializeField] RectTransform scrollObject;

    static CounterZone counterZone;

    float initialY;

    private void Start()
    {
        initialY = scrollObject.rect.position.y;
        counterZone = cZone;

        InitializeObjectsInLine();
    }

    void InitializeObjectsInLine()
    {
        // Para saber a que counter hace referencia el objectInLine, solo hace falta saber el índice de ese objectInLine ya que coincide con el counter al que hace referencia
        for (int i = 0; i < counterZone.counters.Count; i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(false);
            objectInLines[i].index = i;
        }

        for (int i = 0; i < counterZone.ActiveSpots(); i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(true);
        }
    }

    public override void Init()
    {
        base.Init();
        scrollObject.position = new Vector2(scrollObject.position.x, initialY);

    }
    public override void End()
    {

        base.End();
    }

    static public void UpdateCounterAttributes(int index)
    {
        counterZone.counters[index].UpdateAttributes();
    }
}
