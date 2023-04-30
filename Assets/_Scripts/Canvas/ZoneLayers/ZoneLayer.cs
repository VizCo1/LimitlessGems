using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLayer : Layer
{
    [SerializeField] protected ObjectInLine[] objectInLines;

    public int activeSpots { get; protected set; }
    public int maxActiveSpots { get; protected set; }

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

    public override void End()
    {
        gameObject.SetActive(false);
        CameraSystem.inGame = true;
    }

    protected virtual void InitSpotsVariables()
    {
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

    public ObjectInLine[] GetObjectInLines()
    {
        return objectInLines;
    }

    public virtual void CheckButtons()
    {       
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

    protected void UpdateAndCheck()
    {
        CanvasManager.UpdateDisplayedMoney();
        CheckButtons();
    }
}
