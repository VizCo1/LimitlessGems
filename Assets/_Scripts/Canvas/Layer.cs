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

    protected virtual void Awake()
    {
        canvasManager = GetComponentInParent<CanvasManager>();
    }

    protected virtual void Start()
    {
        if (unlockButton != null)
            unlockCostText.text = unlockCost;

        if (majorUpgradeButton != null)
            majorUpgradeCostText.text = majorUpgradeCost;

        InitSpotsVariables();
        InitObjectsInLine();
    }

    public virtual void Init()
    {
        gameObject.SetActive(true);
        CameraSystem.inGame = false;
    }

    public virtual void End()
    {
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

    public void CheckUnlockButton()
    {
        if (!CanvasManager.EnoughCost(unlockCost))
        {
            unlockButton.interactable = false;
        }
        else if (activeSpots >= maxActiveSpots)
        {
            unlockButton.interactable = false;
            unlockCostText.text = "COMPLETED";
        }
        else
        {
            unlockButton.interactable = true;
        }
    }

    protected void UpdateAndCheck()
    {
        CanvasManager.UpdateMoney();
        CanvasManager.CheckAllButtons();
    }

    public void CheckMajorUpgradeButton()
    {
        if (/* Some condition I do not know yet  ||*/ !CanvasManager.EnoughCost(majorUpgradeCost))
            majorUpgradeButton.interactable = false;
        else
            majorUpgradeButton.interactable = true;
    }

    protected void UnlockSpotLogic()
    {
        objectInLines[activeSpots].transform.parent.gameObject.SetActive(true);
        activeSpots++;
        unlockCost = (BigDouble.Parse(unlockCost) * 2).ToString();
        unlockCostText.text = unlockCost;
        GameController.money -= BigDouble.Parse(unlockCost);
        UpdateAndCheck();
    }
}
