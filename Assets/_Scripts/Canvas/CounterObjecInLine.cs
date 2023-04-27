using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterObjecInLine : ObjectInLine
{
    [SerializeField] CounterLayer counterLayer;
    protected override void UpdateAttributesAndCheckCosts()
    {
        counterLayer.UpdateAttributesAndCheckCosts(index);
    }
}
