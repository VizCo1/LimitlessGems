using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class PSpotObjectInLine : ObjectInLine
{
    [NonZSerialized][SerializeField] ParkingLayer parkingLayer;

    [Header("True for Capacity, false for Publicity")]

    [NonZSerialized][SerializeField] bool type;

    protected override void UpdateAttributesAndCheckCosts()
    {
        parkingLayer.UpdateAttributesAndCheckCosts(type);//, ref keyLevel, initialKeyLevel);
    }

    public override void UpgradeButtonPressed()
    {
        if (!IsLevelMax && !CanvasManager.EnoughCost(levelCost))
        {
            return;
        }

        GameController.money -= BigDouble.Parse(levelCost);

        if (++level == realMaxLevel)
        {
            IsLevelMax = true;
            levelCost = "FULL";
            costNumber.text = levelCost;
        }
        else
        {
            levelCost = (BigDouble.Parse(costNumber.text) * 1.5f).ToString("G1");
            costNumber.text = levelCost;
        }

        levelNumber.text = level.ToString();

        UpdateAttributesAndCheckCosts();
    }
}
