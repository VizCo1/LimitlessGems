using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;
using ZSerializer;

public class SpecialZoneLayer : ZoneLayer
{
    [NonZSerialized][SerializeField] Button unlockButton; // no
    [SerializeField] string unlockCost; // save
    [NonZSerialized][SerializeField] protected TMP_Text unlockCostText; // no

    [Space]

    [NonZSerialized][SerializeField] Button majorUpgradeButton; // no
    [SerializeField] string majorUpgradeCost; // save
    [NonZSerialized][SerializeField] protected TMP_Text majorUpgradeCostText; // no

    [Space]

    public int mUpgradeTarget = 50; // save
    [SerializeField] int requiredSpots = 5; // save
    protected int initialRequiredSpots; // no
    [HideInInspector][SerializeField] bool canMajorUpgrade = false; // save

    protected virtual void Awake()
    {
        initialRequiredSpots = requiredSpots;      
    }

    protected virtual void Start()
    {
        unlockCost = (BigDouble.Parse(unlockCost)).ToString("G1");
        majorUpgradeCost = (BigDouble.Parse(majorUpgradeCost)).ToString("G1");

        unlockCostText.text = unlockCost;
        majorUpgradeCostText.text = majorUpgradeCost;
    }

    /*public override void OnPostLoad()
    {
        unlockCost = (BigDouble.Parse(unlockCost)).ToString("G1");
        majorUpgradeCost = (BigDouble.Parse(majorUpgradeCost)).ToString("G1");

        unlockCostText.text = unlockCost;
        majorUpgradeCostText.text = majorUpgradeCost;
    }*/

    public override void CheckButtons()
    {
        CheckMajorUpgradeButton();
        CheckUnlockButton();

        base.CheckButtons();
    }

    void CheckUnlockButton()
    {
        if (activeSpots >= maxActiveSpots)
        {
            unlockButton.interactable = false;
            unlockCostText.text = "COMPLETED";
        }
        else if (activeSpots == requiredSpots)
        {
            unlockButton.interactable = false;
        }
        else if (!CanvasManager.EnoughCost(unlockCost))
        {
            unlockButton.interactable = false;
        }
        else
        {
            unlockButton.interactable = true;
        }
    }

    protected bool MajorUpgradeSpecificConditions()
    {
        if (activeSpots != requiredSpots)
            return false;

        for (int i = 0; i < activeSpots; i++)
        {
            if (!objectInLines[i].IsLevelMax)
                return false;
        }

        return true;
    }

    void CheckMajorUpgradeButton() 
    {
        if (MajorUpgradeSpecificConditions())
        {          
            majorUpgradeButton.gameObject.SetActive(true);

            if (!CanvasManager.EnoughCost(majorUpgradeCost))
            {
                majorUpgradeButton.interactable = false;
            }
            else
            {
                majorUpgradeButton.interactable = true;
                canMajorUpgrade = true;
            }
        }
        else
        {
            majorUpgradeButton.gameObject.SetActive(false);
        }
    }


    protected bool MajorUpgradeLogic()
    {
        if (!canMajorUpgrade && !CanvasManager.EnoughCost(majorUpgradeCost))
        {
            return false;
        }
        canMajorUpgrade = false;
        
        GameController.money -= BigDouble.Parse(majorUpgradeCost);
        majorUpgradeCost = (BigDouble.Parse(majorUpgradeCost) * 5).ToString("G1");
        majorUpgradeCostText.text = majorUpgradeCost;
        
        requiredSpots += initialRequiredSpots;
        
        for (int i = 0; i < activeSpots; i++)        
            objectInLines[i].IsLevelMax = false;
    
        mUpgradeTarget += mUpgradeTarget;

        UpdateAndCheck();

        return true;
    }

    protected bool UnlockSpotLogic()
    {
        if (!CanvasManager.EnoughCost(unlockCost))
        {
            return false;
        }

        objectInLines[activeSpots].transform.parent.gameObject.SetActive(true);
        activeSpots++;
        GameController.money -= BigDouble.Parse(unlockCost);
        unlockCost = (BigDouble.Parse(unlockCost) * 4).ToString("G1");
        unlockCostText.text = unlockCost;
        UpdateAndCheck();

        return true;
    }
}
