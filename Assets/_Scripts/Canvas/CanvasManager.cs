using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;

public class CanvasManager : MonoBehaviour
{
    [Header("Index of 'Top row'")]
    [SerializeField] int topRowIndex = 0;
    static TopRow topRow;

    [Space]

    [Header("Canvas layers")]
    [SerializeField] int numberOfLayers;

    List<Layer> layers = new();

    public static Layer currentLayer;

    private void Awake()
    {       
        topRow = transform.GetChild(topRowIndex).GetComponent<TopRow>();
    }

    private void Start()
    {
        for (int i = 1; i <= numberOfLayers; i++)
            layers.Add(transform.GetChild(i).GetComponent<Layer>());

        currentLayer = layers[0];

        foreach (Layer l in layers)
        {
            l.Init(true);
            l.End();
        }
    }

    public void OpenLayer(int layer)
    {
        layers[layer].Init(false);
        currentLayer = layers[layer];
    }

    public void CloseLayer(int layer)
    {
        layers[layer].End();
    }

    public static void UpdateDisplayedMoney()
    {
        topRow.UpdateMoneyText(GameController.money);
    }

    /*static public void CheckAllButtons()
    {
        foreach (Layer l in layers)
        {
            ObjectInLine[] objs = l.GetObjectInLines();

            foreach (ObjectInLine obj in objs)
            {
                if (!EnoughCost(obj.LevelCost()))
                    obj.UpgradeButton().interactable = false;
                else if (obj.IsLevelMax)
                    obj.UpgradeButton().interactable = false;
                else
                    obj.UpgradeButton().interactable = true;
            }

            l.CheckUnlockButton();
            l.CheckMajorUpgradeButton();
        }
    }*/


    static public bool EnoughCost(string cost)
    {
        if (cost == "FULL" || cost == "COMPLETED")
            return false;

        return BigDouble.Parse(cost) <= GameController.money;
    }
}
