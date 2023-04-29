using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;

public class Layer : MonoBehaviour
{
    CanvasManager canvasManager;

    [Space]

    [SerializeField] protected ObjectInLine[] objectInLines;

    [Space]

    [SerializeField] Button unlockButton;
    [SerializeField] protected string unlockCost;
    [SerializeField] protected TMP_Text unlockCostText;

    [Space]

    [SerializeField] Button majorUpgradeButton;
    [SerializeField] protected string majorUpgradeCost;
    [SerializeField] protected TMP_Text majorUpgradeCostText;

    public int activeSpots { get; protected set; }
    public int maxActiveSpots { get; protected set; }

    [Space]

    public int mUpgradeTarget = 50;
    [SerializeField] protected int requiredSpots = 5;
    protected int initialRequiredSpots;
    protected bool canMajorUpgrade = false;

    protected virtual void Awake()
    {
        canvasManager = GetComponentInParent<CanvasManager>();
        initialRequiredSpots = requiredSpots;      
    }

    protected virtual void Start()
    {
        
        if (unlockButton != null)
            unlockCostText.text = unlockCost;

        if (majorUpgradeButton != null)
            majorUpgradeCostText.text = majorUpgradeCost;
       
    }

    public virtual void Init(bool b)
    {
        if (b)
        {
            InitSpotsVariables();
            InitObjectsInLine();
        }
        else
        {
            gameObject.SetActive(true);
            CameraSystem.inGame = false;
            CheckButtons();
        }
    }

    public virtual void End()
    {
        //CheckButtons();
        gameObject.SetActive(false);
        CameraSystem.inGame = true;
    }

    protected virtual void InitObjectsInLine()
    {
        for (int i = 0; i < maxActiveSpots; i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(false);
            objectInLines[i].index = i;
        }

        for (int i = 0; i < activeSpots; i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(true);
        }
    }

    protected virtual void InitSpotsVariables()
    {
    }

    public void BackButtonPressed()
    {
        End();
    }

    public ObjectInLine[] GetObjectInLines()
    {
        return objectInLines;
    }

    public void CheckButtons()
    {
        CheckMajorUpgradeButton();
        CheckUnlockButton();
        
        for (int i = 0; i < activeSpots; i++)
        {
            ObjectInLine obj = objectInLines[i];
            if (obj.IsLevelMax)           
                obj.UpgradeButton().interactable = false;        
            else if (!CanvasManager.EnoughCost(obj.LevelCost()))
                obj.UpgradeButton().interactable = false;
            else
                obj.UpgradeButton().interactable = true;
        }
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

    protected void UpdateAndCheck()
    {
        CanvasManager.UpdateDisplayedMoney();
        CheckButtons();
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
        majorUpgradeCost = (BigDouble.Parse(majorUpgradeCost) * 2).ToString();
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
        unlockCost = (BigDouble.Parse(unlockCost) * 2).ToString();
        unlockCostText.text = unlockCost;
        UpdateAndCheck();

        return true;
    }
}
