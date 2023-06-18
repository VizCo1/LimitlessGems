using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class CounterObjectInLine : ObjectInLine
{
    [NonZSerialized][SerializeField] CounterLayer counterLayer;
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
