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
    [SerializeField] Layer[] layers;
    //[SerializeField] int currentLayer = 0;

    private void Awake()
    {       
        topRow = transform.GetChild(topRowIndex).GetComponent<TopRow>();
    }

    private void Start()
    {
        // Probablemente no se utilice esto
        foreach (Layer l in layers) l.End();

        //layers[currentLayer].Init();
    }

    public void OpenLayer(int layer)
    {
        //layers[currentLayer].End();
        //currentLayer = layer;

        layers[layer].Init();
    }

    public void CloseLayer(int layer)
    {
        layers[layer].End();
    }

    public static void UpdateMoney(BigDouble money)
    {
        topRow.UpdateMoneyText(money);
    }

    public void CheckAllButtons()
    {
        //TODO --> IMPORTANTE: Cuando gastas dinero hay que revisar todos los botones para ver si tienes suficiente dinero 
    }

}
