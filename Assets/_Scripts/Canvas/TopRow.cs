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

    private void Start()
    {
        UpdateMoneyText(GameController.money);   
    }

    public void UpdateMoneyText(BigDouble m)
    {
        money.text = m.ToString("E4");
    }

    public void UpdateMoneyPerMinuteText(BigDouble m)
    {
        moneyPerMinute.text = m.ToString();
    }
}
