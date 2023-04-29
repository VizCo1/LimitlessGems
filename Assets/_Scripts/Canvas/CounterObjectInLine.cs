using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterObjectInLine : ObjectInLine
{
    [SerializeField] CounterLayer counterLayer;
    [SerializeField] int keyLevel = 25;
    int initialKeyLevel;

    private void Awake()
    {
        initialKeyLevel = keyLevel;
    }

    protected override void UpdateAttributesAndCheckCosts()
    {
        counterLayer.UpdateAttributesAndCheckCosts(index, ref keyLevel, initialKeyLevel);
    }

    protected override bool IsTargetLevelReached()
    {
        return level == counterLayer.mUpgradeTarget;
    }
}
