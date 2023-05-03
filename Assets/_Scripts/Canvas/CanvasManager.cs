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
    [SerializeField] Layer optionsLayer;

    List<ZoneLayer> layers = new();

    public static ZoneLayer currentLayer;

    private void Awake()
    {       
        topRow = transform.GetChild(topRowIndex).GetComponent<TopRow>();
    }

    private void Start()
    {
        for (int i = 2; i <= numberOfLayers + 1; i++)
        {
            layers.Add(transform.GetChild(i).GetComponent<ZoneLayer>());
            //Debug.Log(layers[i - 2]);
        }

        currentLayer = layers[0];

        foreach (ZoneLayer l in layers)
        {
            l.Init(true);
            l.End();
        }
    }

    public void OpenOptions()
    {
        optionsLayer.Init();
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


    public static void UpdateDisplayedGems(int gem, int quantity)
    {
        topRow.UpdateGemQuantityText(gem, quantity);
    }

    public static void UpdateDisplayedMoney()
    {
        topRow.UpdateMoneyText(GameController.money);
    }

    static public bool EnoughCost(string cost)
    {
        if (cost == "FULL" || cost == "COMPLETED")
            return false;

        return BigDouble.Parse(cost) <= GameController.money;
    }
}
