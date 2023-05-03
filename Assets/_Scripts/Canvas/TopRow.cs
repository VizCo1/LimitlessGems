using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BreakInfinity;
using System;

public class TopRow : MonoBehaviour
{
    [SerializeField] TMP_Text money;
    [SerializeField] TMP_Text gem1;
    [SerializeField] TMP_Text gem2;
    [SerializeField] TMP_Text gem3;

    private void Start()
    {
        UpdateMoneyText(GameController.money);   
    }

    public void UpdateMoneyText(BigDouble m)
    {
        money.text = m.ToString("G1");
    }

    public void UpdateGemQuantityText(int gem, int quantity)
    {
        switch (gem)
        {
            case 0:
                gem1.text = quantity.ToString();
                break;

            case 1:
                gem2.text = quantity.ToString();
                break;

            case 2:
                gem3.text = quantity.ToString();
                break;
        }
    }
}
