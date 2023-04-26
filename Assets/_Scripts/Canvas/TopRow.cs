using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BreakInfinity;
using System;

public class TopRow : MonoBehaviour
{
    [SerializeField] TMP_Text money;
    [SerializeField] TMP_Text moneyPerMinute;

    [SerializeField] string[] moneyFormats;

    private void Awake()
    {
        money.text = GameController.money.ToString();      
    }

    public void UpdateMoneyText(BigDouble m)
    {
        int index;

        if (m >= 1000000)
        {
            index = 1;
        }
        else
        {
            index = 0;
        }

        money.text = m.ToString(moneyFormats[index]);
    }

    public void UpdateMoneyPerMinuteText(BigDouble m)
    {
        moneyPerMinute.text = m.ToString();
    }
}
