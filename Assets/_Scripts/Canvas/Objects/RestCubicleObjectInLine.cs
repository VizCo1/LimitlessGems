using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class RestCubicleObjectInLine : ObjectInLine
{
    [NonZSerialized][SerializeField] RestLayer restLayer;
    [SerializeField] int keyLevel = 25;
    int initialKeyLevel;

    private void Awake()
    {
        initialKeyLevel = keyLevel;
    }

    protected override void UpdateAttributesAndCheckCosts()
    {
        restLayer.UpdateAttributesAndCheckCosts(index, ref keyLevel, initialKeyLevel);
    }

    protected override bool IsTargetLevelReached()
    {
        return level == restLayer.mUpgradeTarget;
    }   
}
