using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class WorkLayer : SpecialZoneLayer
{
    [NonZSerialized][SerializeField] WorkZone workZone;

    protected override void InitSpotsVariables()
    {
        activeSpots = workZone.ActiveSpots;
        maxActiveSpots = workZone.MaxActiveSpots;
    }

    public void UpdateAttributesAndCheckCosts(int index) //, ref int keyLevel, int initialKeyLevel)
    {
        UpdateAndCheck();
        workZone.tables[index].UpdateAttributes();
        /*if (objectInLines[index].level >= keyLevel)
        {
            keyLevel += initialKeyLevel;
            workZone.tables[index].UpdateAttributes();
        }
        else
        {
            workZone.tables[index].UpdateAttributes();
        }*/
    }

    public void UnlockTable()
    {
        if (UnlockSpotLogic())
            workZone.AddTable();
    }

    public void MajorUpgrade()
    {
        if (MajorUpgradeLogic())
            workZone.MajorUpgrade();
    }
}
