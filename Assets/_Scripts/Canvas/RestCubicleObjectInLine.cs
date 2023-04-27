using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCubicleObjectInLine : ObjectInLine
{
    [SerializeField] RestLayer restLayer;
    protected override void UpdateAttributesAndCheckCosts()
    {
        restLayer.UpdateAttributesAndCheckCosts(index);
    }
}
