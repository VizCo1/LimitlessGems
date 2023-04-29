using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableObjectInLine : ObjectInLine
{
    [SerializeField] WorkLayer workLayer;
    //[SerializeField] int keyLevel = 25;
    //int initialKeyLevel;

    private void Awake()
    {
        //initialKeyLevel = keyLevel;
    }

    protected override void UpdateAttributesAndCheckCosts()
    {
        workLayer.UpdateAttributesAndCheckCosts(index);//, ref keyLevel, initialKeyLevel);
    }

    protected override bool IsTargetLevelReached()
    {
        return level == workLayer.mUpgradeTarget;
    }
}
