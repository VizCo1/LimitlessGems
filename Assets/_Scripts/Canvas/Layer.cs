using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Layer : MonoBehaviour
{
    CanvasManager canvasManager;

    [Space]

    [SerializeField] RectTransform scrollObject;
    [SerializeField] protected ObjectInLine[] objectInLines;

    [Space]

    [SerializeField] Button unlockButton;
    [SerializeField] protected string unlockCost;
    [SerializeField] protected TMP_Text unlockCostText;

    [Space]

    [SerializeField] Button majorUpgradeButton;
    [SerializeField] protected string majorUpgradeCost;
    [SerializeField] protected TMP_Text majorUpgradeCostText;
    

    float initialY;
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
        initialY = scrollObject.rect.position.y;
        InitializeObjectsInLine();
    }

    public virtual void Init()
    {
        gameObject.SetActive(true);
        CameraSystem.inGame = false;
        scrollObject.position = new Vector2(scrollObject.position.x, initialY);
    }

    public virtual void End()
    {
        gameObject.SetActive(false);
        CameraSystem.inGame = true;
    }

    protected virtual void InitializeObjectsInLine()
    {

    }

    protected void CheckButtons()
    {
        canvasManager.CheckAllButtons();
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
        Debug.Log(!CanvasManager.EnoughCost(unlockCostText.text));
        if (activeSpots >= maxActiveSpots || !CanvasManager.EnoughCost(unlockCostText.text))
            unlockButton.interactable = false;
        else
            unlockButton.interactable = true;
    }

    public void CheckMajorUpgradeButton()
    {
        if (/* Some condition I do not know yet  ||*/ !CanvasManager.EnoughCost(majorUpgradeCost))
            majorUpgradeButton.interactable = false;
    }
}
