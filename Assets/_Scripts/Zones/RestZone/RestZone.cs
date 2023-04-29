using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestZone : QueueZone
{
    public List<RestCubicle> cubicles { get; private set; } = new();

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < transform.GetChild(SLOTS_INDEX).childCount; i++)
            cubicles.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<RestCubicle>());
    }

    public override void MajorUpgrade()
    {
        foreach (RestCubicle cub in cubicles)
        {
            cub.DoMajorUpdate();
        }
    }
}
